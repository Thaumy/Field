<template>
  <div>

    <f-card
        class="margin-bottom"
        style="overflow: hidden"
    >
      <transition-group name="comment-zone">

        <!-- TODO 此实现有缺陷，当收起动画未完成时，回复仍然有效。并且不能适应后期缩放 -->
        <f-slider
            ref="replyTargetZone"
            :after-closed="()=>{this.replyTarget=postId}"
        >
          <div
              class="reply-target-zone"
              key="reply-target-zone"
          >
            <div class="reference-bar"/>
            <CommentCard
                class="reference-filter"
                :comment="getCommentById(replyTarget)"
                :disable-reply=true
            >
              <template #user-name-right-end-slot>
                <v-icon icon="mdi-close"
                        size="x-small"
                        color="grey"
                        @click="$refs.replyTargetZone.close()"
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
                :comment='comment'
                :enable-reply='replyTo!==comment.id'
                @reply-click="replyTo(comment);expandReference(index)"
            />
          </div>

        </div>

      </transition-group>
    </f-card>

  </div>
</template>

<script setup lang="ts">
import {PropType, Ref, ref} from "vue"
import {Comment} from "@/scripts/comment"
import CommentEditor from './CommentEditor.vue'
import CommentCard from './CommentCard.vue'
import FSlider from "@/components/field/f-slider.vue"
import FCard from "@/components/field/f-card.vue"
import FDivider from "@/components/field/f-divider.vue"

defineProps({
  postId: Number
})

const replyTarget = ref(12384)

const comments = [
  <Comment>{
    id: 1000,
    user: '小品',
    body: '这是一条评论！',
    replyTo: null,
    siteUrl: 'https://www.thaumy.cn',
    avatarUrl: null,
    createTime: "22-08-11 | 01:34"
  },
  <Comment>{
    id: 1001,
    user: 'Thaumy',
    body:
        '贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴' +
        '贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴' +
        '贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴',
    replyTo: 1000,
    siteUrl: 'https://www.thaumy.cn',
    avatarUrl: null,
    createTime: "22-08-12 | 02:12"
  },
  <Comment>{
    id: 1002,
    user: '小品',
    body: '不许贴贴！',
    replyTo: 1000,
    siteUrl: 'https://www.thaumy.cn',
    avatarUrl: null,
    createTime: "22-08-13 | 03:51"
  },
  <Comment>{
    id: 1003,
    user: 'Fubuki',
    body: 'moemoemoemoemoemoemoemoemoemoemoemoe',
    replyTo: null,
    siteUrl: null,
    avatarUrl: null,
    createTime: '22-08-13 | 05:15'
  }]

function getCommentById(id: Number) {
  return comments.filter(x => x.id === id)[0]
}

function replyTo(comment: Comment) {
  replyTarget.value = comment.id;
}

const replyTargetZone = ref()
const commentList = ref()

function expandReference(index: number) {
  const height = commentList.value[index].children[index === 0 ? 0 : 1].offsetHeight
  replyTargetZone.value.expand(height)
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
