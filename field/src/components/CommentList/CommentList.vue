<template>
  <div>

    <div class="comment-list margin-bottom border-line border-radius-all">
      <transition-group name="comment-list">

        <div class="reply-target-zone" v-if="replyTo!==postId" key="reply-target-zone">
          <div class="reference-bar"></div>

          <CommentCard class="reference-filter" :comment="getCommentById(replyTo)" :enable-reply=false>
            <template v-slot:user-name-right-end-slot>
              <v-icon icon="mdi-close" size="x-small" color="grey" @click="replyTo=postId"/>
            </template>
          </CommentCard>
        </div>

        <CommentEditor :reply-mode="replyTo!==postId" key="comment-editor"/>

        <div>
          <div v-for="item in comments" :key="item">
            <div class="comment-divider"/>
            <CommentCard :comment='item' @do-reply="replyTo=item.id"/>
          </div>
        </div>

      </transition-group>
    </div>

  </div>
</template>

<script setup lang="ts">
import CommentEditor from './CommentEditor.vue'
import CommentCard from './CommentCard.vue'
import {Comment} from "@/scripts/comment";
import {Ref, ref} from "vue";

//TODO add props
const postId = ref(12384)
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

<style scoped>

.reply-target-zone {
  display: grid;
  grid-template-columns: 2px auto;
  position: relative;
  max-height: 100vh;
  overflow: hidden;
}

.comment-list-enter-active,
.comment-list-leave-active {
  transition: all 2s ease;
}

.comment-list-leave-to,
.comment-list-enter-from {
  max-height: 0;
  opacity: 0;
  transform-origin: top;
  transform: rotateX(90deg);
}

/*
.comment-list-leave-to {
}

.comment-list-leave-active {
  position: absolute;
}*/

.reference-filter {
  filter: grayscale(0.6);
}

.reference-bar {
  width: 2px;
  background-color: #0078d7;
}

.comment-divider {
  border-top: 1px solid rgb(50, 50, 50);
  margin-left: 44px;
  margin-right: 8px
}

.comment-list {
  width: 100%;
  overflow: hidden;
  /* 颜色模式 */
  background: var(--b30);
  transition: all 0.2s ease;
}

</style>