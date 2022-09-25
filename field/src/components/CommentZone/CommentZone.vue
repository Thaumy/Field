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

          <CommentCard
              class="reference-filter"
              :comment="getCommentIn(_comments,_binding)"
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
        </div>
      </f-slider>

      <DisableCommentHolder v-if="disableComment"/>
      <CommentEditor
          ref="commentEditor"
          v-else
          :is-reply="_isReply"
          @create-comment="createCommentHandler"
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
              :comment='comment'
              name="comment-card"
              :disable-reply='_binding===comment.id&&_isReply'
              @reply-click="()=>{
                this._binding=comment.id
                this._isReply=true
                expandReference(index)
              }"
          >
            <template #body-top-slot v-if="comment.isReply">
              <f-text-render
                  name="comment-card-reply"
                  :text="genReplyReference(getCommentIn(_comments,comment.binding))"
              />
            </template>
          </CommentCard>
        </div>

      </transition-group>

    </f-card>

  </div>
</template>

<script lang="ts" setup>

import {PropType, Ref, ref} from "vue"
import {formatToDateTime} from "@/scripts/util/time"
import {Comment, getCommentIn} from "@/scripts/type/comment"
import {createComment} from "@/scripts/data/comment"
import CommentCard from "./CommentCard.vue"
import CommentEditor from "./CommentEditor.vue"
import NoCommentHolder from "./NoCommentHolder.vue"
import DisableCommentHolder from "./DisableCommentHolder.vue"

const props =
    defineProps<{
      postId: number,
      comments: Comment[],
      disableComment: boolean
    }>()

const _comments = ref(props.comments)
const _binding = ref(props.postId)
const _isReply = ref(false)

const commentEditor = ref()

async function createCommentHandler(body: string) {
  const comment = <Comment>{
    id: 0,
    user: "",
    body: body,
    binding: _binding.value,
    isReply: _isReply.value,
    siteUrl: "",
    avatarUrl: "",
    createTime: new Date(),
  }
  const response = await createComment(comment)
  if (response !== null) {
    _comments.value.push(response)
  }
  //恢复编辑器状态
  replyTargetSlider.value.close()
  commentEditor.value.reset()
}

function genReplyReference(comment: Comment) {
  return '<blockquote style="font-size:0.8rem;">' +
      comment.user + ` (于${formatToDateTime(comment.createTime)}):<br>` +
      comment.body +
      '</blockquote>'
}

const replyTargetSlider = ref()
const commentList = ref()

function expandReference(index: number) {
  //TODO 此实现超级不优雅！！！
  const card = commentList.value[index].children.namedItem('comment-card')
  const blockQuote = card.children[0].children[3].children.namedItem('comment-card-reply')
  if (blockQuote !== null)
    replyTargetSlider.value.expand(card.offsetHeight - blockQuote.offsetHeight)
  else
    replyTargetSlider.value.expand(card.offsetHeight)
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
