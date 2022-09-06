<template>
  <div>

    <f-card
        class="border-radius-all border-line"
        style="overflow: hidden"
    >
      <transition-group name="comment-zone">

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
                :comment="getCommentIn(comments,replyTarget)"
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

        <CommentEditor :reply-mode="replyTarget!==postId"/>

        <f-divider/>
        <div class="comment-list">

          <div v-for="(comment,index) in comments" ref="commentList">
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
                    :text="genReplyReference(getCommentIn(comments,comment.replyTo))"
                />
              </template>
            </CommentCard>
          </div>

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

const props = defineProps<{
  postId: number,
  comments: Comment[]
}>()

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

.comment-divider
  border-top 1px solid rgb(50 50 50)
  margin-left 44px
  margin-right 8px

.reply-target-zone
  display grid
  grid-template-columns 2px auto
  overflow hidden

.comment-zone-enter-active
.comment-zone-leave-active
  transition all 0.2s ease

.comment-zone-leave-to
.comment-zone-enter-from
  height 0
  opacity 0

.reference-filter
  filter saturate(0.6)
  background-color rgba(100 100 100 0.1)

.reference-bar
  width 2px
  background-color #0199ff

</style>
