<template>
  <div>

    <f-card
        class="border-radius-all border-line"
        style="overflow: hidden"
    >

      <!-- TODO 此实现有缺陷，当收起动画未完成时，回复仍然有效。并且不能适应后期缩放 -->
      <f-slider
          ref="replyTargetSlider"
          :after-closed="()=>{
            this._binding=this.props.postId
            this._isReply=false
          }"
      >
        <div
            class="reply-target-zone"
            key="reply-target-zone"
        >
          <div class="reference-bar"/>

          <f-data
              :provider="async () => findComment(_binding)"
              v-slot="comment"
          >
            <CommentCard
                class="reference-filter"

                :body="comment.Body"
                :userName="comment.UserName"
                :userSiteUrl="comment.UserSiteUrl"
                :userAvatarUrl="comment.UserAvatarUrl"
                :createTime="comment.CreateTime"

                :disable-reply="true"
            >
              <template #user-name-right-end-slot>
                <v-icon
                    icon="mdi-close"
                    size="x-small"
                    color="grey"
                    @click="$refs.replyTargetSlider.close()"
                />
              </template>
            </CommentCard>
          </f-data>
        </div>
      </f-slider>

      <DisableCommentHolder v-if="disableComment"/>
      <CommentEditor
          ref="commentEditor"
          v-else
          :is-reply="_isReply"
          @create-comment="body=>create(body)"
      />

      <f-divider/>

      <transition-group
          name="comment-list"
          tag="div"
      >
        <NoCommentHolder key="" v-if="_comments.length===0&&!disableComment"/>
        <div
            key=""
            ref="commentList"
            v-for="(comment,index) in _comments"
        >
          <f-divider ml="48" v-if="index!==0"/>

          <CommentCard
              name="comment-card"

              :body="comment.Body"
              :userName="comment.UserName"
              :userSiteUrl="comment.UserSiteUrl"
              :userAvatarUrl="comment.UserAvatarUrl"
              :createTime="comment.CreateTime"

              :disable-reply='_binding===comment.Id&&_isReply'
              @reply-click="onReplyBtnClick(comment.Id,index)"
          >
            <template #body-top-slot v-if="comment.IsReply">
              <f-text-render
                  name="comment-card-reply"
                  :text="genReplyReference(findComment(comment.Binding))"
              />
            </template>
          </CommentCard>
        </div>

      </transition-group>

    </f-card>

  </div>
</template>

<script lang="ts" setup>

import {ref} from "vue"
import {formatToDateTime} from "@/scripts/util/time"
import CommentCard from "./CommentCard.vue"
import CommentEditor from "./CommentEditor.vue"
import NoCommentHolder from "./NoCommentHolder.vue"
import DisableCommentHolder from "./DisableCommentHolder.vue"
import FCard from "@/components/field/f-card.vue"
import FSlider from "@/components/field/f-slider.vue"
import FDivider from "@/components/field/f-divider.vue"
import FTextRender from "@/components/field/f-text-render.vue"
import {Rsp as Comment} from "~/scripts/data/client/api/comment/create/rsp"
import FData from "~/components/field/f-data.vue"

const props =
    defineProps<{
      postId: bigint,
      comments: Comment[],
      disableComment: boolean
    }>()

const _comments = ref(props.comments)
const _binding = ref(props.postId)
const _isReply = ref(false)

const commentEditor = ref()

async function create(body: string) {
  const {handler: createComment} =
      await import("@/scripts/data/client/api/comment/create/handler")
  const comment = await createComment({
    Binding: _binding.value,
    IsReply: _isReply.value,
    Body: body
  })
  if (comment.Ok) {
    _comments.value.push(comment.Data)
  }
  //恢复编辑器状态
  replyTargetSlider.value.close()
  commentEditor.value.reset()
}

function findComment(id: bigint) {
  return _comments.value.filter(x => x.Id === id)[0]
}

function genReplyReference(comment: Comment) {
  //TODO use TSX
  return '<blockquote style="font-size:0.8rem;">' +
      comment.UserName + ` (于${formatToDateTime(comment.CreateTime)}):<br>` +
      comment.Body +
      '</blockquote>'
}

const replyTargetSlider = ref()
const commentList = ref()

function expandReference(index: number) {
  //TODO 此实现超级不优雅！！！
  const card = commentList.value[index].children.namedItem('comment-card')
  const blockQuote = card
      .children[0]
      .children[3]
      .children
      .namedItem('comment-card-reply')
  if (blockQuote !== null)
    replyTargetSlider.value.expand(card.offsetHeight - blockQuote.offsetHeight)
  else
    replyTargetSlider.value.expand(card.offsetHeight)
}

//TODO 不优雅
function onReplyBtnClick(comment_id: bigint, index: number) {
  _binding.value = comment_id
  _isReply.value = true
  expandReference(index)
}


</script>

<style lang="stylus" scoped>

.reply-target-zone
  display grid
  grid-template-columns 2px auto
  overflow hidden

.comment-list-enter-active
.comment-list-leave-active
  transition all 0.2s ease

.comment-list-leave-to
.comment-list-enter-from
  height 0
  opacity 0
  transform translateX(20px)

.comment-list-enter-to
  height 100%

.reference-filter
  filter saturate(0.6)
  background-color rgba(100 100 100 0.1)

.reference-bar
  width 2px
  background-color #0199ff

</style>
