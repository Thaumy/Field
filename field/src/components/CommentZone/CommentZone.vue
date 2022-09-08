<template>
  <div>

    <f-card
        class="border-radius-all border-line"
        style="overflow: hidden"
    >

      <!-- TODO 此实现有缺陷，当收起动画未完成时，回复仍然有效。并且不能适应后期缩放 -->
      <f-slider
          ref="replyTargetSlider"
          :after-closed="()=>{this.replyTarget=this.props.postId}"
      >
        <div
            class="reply-target-zone"
            key="reply-target-zone"
        >
          <div class="reference-bar"/>

          <CommentCard
              class="reference-filter"
              :comment="getCommentIn(_comments,replyTarget)"
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
          v-else
          :reply-mode="replyTarget!==postId"
          @create-comment="_comments.push(commentExample)"
      />

      <f-divider/>

      <transition-group
          name="comment-list"
          tag="div"
      >
        <NoCommentHolder key="" v-if="_comments.length===0&&!disableComment"/>
        <div
            v-for="(comment,index) in _comments"
            ref="commentList"
            key=""
        >
          <f-divider ml="48" v-if="index!==0"/>

          <CommentCard
              name="comment-card"
              :comment='comment'
              :disable-reply='replyTarget===comment.id'
              @reply-click="replyTarget=comment.id;expandReference(index)"
          >
            <template #body-top-slot v-if="comment.replyTo!==postId">
              <f-text-render
                  name="comment-card-reply"
                  :text="genReplyReference(getCommentIn(_comments,comment.replyTo))"
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
import {Comment, getCommentIn} from "@/scripts/type/comment"
import CommentEditor from './CommentEditor.vue'
import CommentCard from './CommentCard.vue'
import FSlider from "@/components/field/f-slider.vue"
import FCard from "@/components/field/f-card.vue"
import FDivider from "@/components/field/f-divider.vue"
import FTextRender from "@/components/field/f-text-render.vue"
import {formatToDateTime} from "@/scripts/util/time"
import NoCommentHolder from "@/components/CommentZone/NoCommentHolder.vue";
import DisableCommentHolder from "@/components/CommentZone/DisableCommentHolder.vue";

const props = defineProps<{
  postId: number,
  comments: Comment[],
  disableComment: boolean
}>()

const commentExample = <Comment>{
  id: 1000,
  user: '小品',
  body: '这是一条很长很长很长很长很长很长很长很长很长的评论！',
  replyTo: props.postId,
  siteUrl: 'https://www.thaumy.cn',
  avatarUrl: '/src/assets/comment_user_avatars/kurumi.jpg',
  createTime: new Date('2022-08-11T01:34:00')
}

const _comments = ref(props.comments)
const replyTarget = ref(props.postId)

const genReplyReference = (comment: Comment) =>
    '<blockquote style="font-size:0.8rem;margin-bottom:0.2rem">' +
    comment.user + ` (于${formatToDateTime(comment.createTime)}):<br>` +
    comment.body +
    '</blockquote>'

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
