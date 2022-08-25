<template>
  <div>

    <div class="card"
         @mouseover="showReplyIcon()"
         @mouseleave="hideReplyIcon()"
    >

      <div class="avatar-zone">
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
            class="web-icon"
            icon="mdi-web"
            size="10"
            color="blue"
            v-if="comment.siteUrl"
        />
      </div>


      <div class="user-name">{{ comment.user }}
        <slot name="user-name-right-slot"/>
      </div>

      <div class="user-name-right-end-slot">
        <slot name="user-name-right-end-slot"/>
      </div>

      <div class="create-time">{{ comment.createTime }}</div>

      <div class="body-left-slot">
        <slot name="body-left-slot"/>
      </div>

      <div class="body">{{ comment.body }}</div>

    </div>

  </div>
</template>

<script setup lang="ts">
import {defineProps, ref} from "vue";
import {Comment} from "@/scripts/comment";

defineProps({
  comment: Comment,
  enableReply: {
    type: Boolean,
    default: true
  }
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

<style lang="stylus" scoped>

.user-name-right-end-slot
  display flex
  justify-content end
  grid-row-start 1
  grid-column-start 4

.card
  display grid
  grid-template-columns 40px auto
  grid-template-rows 22px 18px auto auto

  padding 4px

.reply-btn-enter-active
.reply-btn-leave-active
  transition all 0.2s ease

.reply-btn-leave-to
  opacity 0

.reply-btn-enter-from
  opacity 0
  transform-origin left bottom
  transform rotate(90deg)


.user-name
  align-self end
  font-size 0.8rem
  overflow hidden
  text-overflow ellipsis
  white-space nowrap

  grid-row-start 1
  grid-column-start 2

  padding-left 4px

.create-time
  align-self center
  grid-row-start 2
  grid-column-start 2

  padding-left 4px

  font-size 0.6rem
  color rgba(170 170 170 1)

.avatar-zone
  grid-row-start 1
  grid-row-end 3
  display grid

  grid-template-rows 28px 12px
  grid-template-columns 28px 12px

.user-avatar
  margin 4px

.web-icon
  grid-row-start 2
  grid-column-start 2

.body
  grid-column-start 2

  font-size 0.9rem
  text-align left

  padding-top 4px
  padding-left 4px
  padding-bottom 2px

.body-left-slot
  grid-row-start 3

.user-name
  /* 颜色模式 */
  color var(--w220)

.body
  /* 颜色模式 */
  color var(--w200)

.create-time
  /* 颜色模式 */
  color rgba(170 170 170 1)

</style>