<template>
  <div>

    <f-card
        class="margin-bottom"
        style="overflow: hidden"
    >
      <transition-group name="comment-zone">

        <!-- TODO 此实现有缺陷，当收起动画未完成时，回复仍然有效。并且不能适应后期缩放 -->
        <f-slider
            ref="reply-target-slider"
            :after-closed="()=>{this.replyTo=postId}"
        >
          <div
              class="reply-target-zone"
              key="reply-target-zone"
          >
            <div class="reference-bar"/>
            <CommentCard
                class="reference-filter"
                :comment="getCommentById(replyTo)"
                :enable-reply=false
            >
              <template v-slot:user-name-right-end-slot>
                <v-icon icon="mdi-close"
                        size="x-small"
                        color="grey"
                        @click="$refs['reply-target-slider'].close()"
                />
              </template>
            </CommentCard>
          </div>
        </f-slider>

        <CommentEditor :reply-mode="replyTo!==postId" key="comment-editor"/>

        <div class="editor-divider"/>

        <CommentList :comments="comments"/>

      </transition-group>
    </f-card>

  </div>
</template>

<script setup lang="ts">
import CommentEditor from './CommentEditor.vue'
import CommentCard from './CommentCard.vue'
import {Comment} from "@/scripts/comment";
import {Ref, ref} from "vue";
import FSlider from "@/components/field/f-slider.vue";
import FCard from "@/components/field/f-card.vue";
import CommentList from "@/components/CommentList/CommentList.vue";

defineProps({
  postId: Number
})

const replyTo = ref(12384)

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
</script>

<style lang="stylus" scoped>

.reply-target-zone
  display grid
  grid-template-columns 2px auto
  overflow hidden

.comment-zone-enter-active
.comment-zone-leave-active
  transition all 2s ease

.comment-zone-leave-to
.comment-zone-enter-from
  height 0
  opacity 0

.reference-filter
  filter saturate(0.6)
  background-color rgba(100 100 100 0.1)

.reference-bar
  width 2px
  background-color #0078d7

.editor-divider
  border-top 1px solid rgb(50 50 50)
  margin-left 8px
  margin-right 8px

.comment-divider
  border-top 1px solid rgb(50 50 50)
  margin-left 44px
  margin-right 8px

</style>
