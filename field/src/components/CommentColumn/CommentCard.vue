<template>

  <div class="card border-shadow"
       @mouseover="showReplyIcon()"
       @mouseleave="hideReplyIcon()"
  >
    <v-avatar
        class="user-avatar"
        :class="comment.siteUrl?'cursor-pointer':''"
        rounded="true"
        size="32"
        @click="blankUrl(comment.siteUrl)"
    >
      <v-img :src="avatar" cover="true"/>
    </v-avatar>
    <v-icon
        class="site-icon"
        icon="mdi-web"
        size="10"
        color="blue"
        v-if="comment.siteUrl"
    />
    <div class="user-name">{{ comment.user }}
      <transition name="reply-btn-rotate">
        <v-icon class="reply-btn"
                color="orange"
                icon="mdi-reply"
                size="1.1em"
                @click=""
                v-show="replyIconVisibility"
        />
      </transition>
    </div>
    <div class="create-time">{{ comment.createTime }}</div>
    <div class="body">{{ comment.body }}</div>
  </div>

</template>

<script setup lang="ts">
import {defineProps, ref} from "vue";
import {Comment} from "@/scripts/common";

defineProps({
  comment: Comment
})

const avatar = new URL('../../assets/comment_user_avatars/kurumi.jpg', import.meta.url).href
const replyIconVisibility = ref(false)

function blankUrl(url: string) {
  if (url)
    window.open(url)
}

function showReplyIcon() {
  replyIconVisibility.value = true
}

function hideReplyIcon() {
  replyIconVisibility.value = false
}
</script>

<style scoped>
.card {
  display: grid;
  grid-template-columns: 30px 10px 4px auto;
  grid-template-rows: 20px 20px auto auto;

  padding: 4px;

  border-radius: 2px;
  margin: 4px;
}

.reply-btn-rotate-enter-active,
.reply-btn-rotate-leave-active {
  transition: all 0.2s ease;
}

.reply-btn-rotate-leave-to {
  opacity: 0;
}

.reply-btn-rotate-enter-from {
  opacity: 0;
  transform-origin: left bottom;
  transform: rotate(90deg);
}

.user-avatar {
  margin: 4px;
  grid-row-start: 1;
  grid-row-end: 3;
}

.user-name {
  align-self: end;
  font-size: 0.8rem;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
  grid-column-start: 4;
}


.create-time {
  align-self: center;
  grid-row-start: 2;
  grid-column-start: 4;

  font-size: 0.6rem;
  color: rgba(170, 170, 170, 1);
}

.site-icon {
  grid-row-start: 2;
  grid-column-start: 2;
  align-self: end;
  padding-right: 4px;
  padding-bottom: 4px;
}


.body {
  grid-column-start: 1;
  grid-column-end: 5;

  font-size: 0.9rem;
  text-align: left;

  padding-top: 4px;
  padding-left: 8px;
  padding-bottom: 2px;
}
</style>
<style scoped>
.card {
  /* 颜色模式 */
  background: var(--b30);
}

.user-name {
  /* 颜色模式 */
  color: var(--w220);
}

.body {
  /* 颜色模式 */
  color: var(--w200);
}

.create-time {
  /* 颜色模式 */
  color: rgba(170, 170, 170, 1);
}
</style>