<template>
  <div>

    <div class="comment-card"
         @mouseover="showReplyBtn()"
         @mouseleave="hideReplyBtn()"
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

      <div class="user-name-zone">
        <div class="flex align-self-end">
          <div class="user-name">
            {{ comment.user }}
          </div>

          <transition name="reply-btn" v-if="!disableReply">
            <v-icon class="reply-btn ml-1"
                    color="orange"
                    icon="mdi-reply"
                    size="1.1rem"
                    v-show="replyBtnVisibility"
                    @click="$emit('replyClick',comment)"
            />
          </transition>
        </div>

        <slot name="user-name-right-end-slot"/>
      </div>

      <div class="create-time">{{ formatToDateTime(comment.createTime) }}</div>

      <div class="body-left-slot">
        <slot name="body-left-slot"/>
      </div>

      <div class="body">{{ comment.body }}</div>

    </div>

  </div>
</template>

<script setup lang="ts">
import {defineProps, PropType, ref} from "vue"
import {Comment} from "@/scripts/type/comment"
import {formatToDateTime} from "@/scripts/util/time"

defineEmits<{ (e: 'replyClick', comment: Comment): void }>()

defineProps({
  comment: Object as PropType<Comment>,
  disableReply: {
    type: Boolean,
    default: false
  }
})

const avatar = new URL('../../assets/comment_user_avatars/kurumi.jpg', import.meta.url).href

const replyBtnVisibility = ref(false)

function blankUrl(url: string) {
  if (url)
    window.open(url)
}

function showReplyBtn() {
  replyBtnVisibility.value = true
}

function hideReplyBtn() {
  replyBtnVisibility.value = false
}
</script>

<style lang="stylus" scoped>

.user-name-right-end-slot
  display flex
  justify-content end
  grid-row-start 1
  grid-column-start 4

.comment-card
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

.user-name-zone
  display flex
  justify-content space-between

.user-name
  font-size 0.8rem
  overflow hidden
  text-overflow ellipsis
  white-space nowrap

  grid-row-start 1
  grid-column-start 2

  padding-left 4px

//color var(--w220)
@css {
  .user-name {
    color: rgb(var(--v-theme-on-surface));
  }
}

.create-time
  align-self center
  grid-row-start 2
  grid-column-start 2

  padding-left 4px

  font-size 0.6rem
  color rgba(170 170 170 1)

//color rgba(170 170 170 1)
@css {
  .create-time {
    color: rgba(var(--v-theme-on-surface), var(--v-medium-emphasis-opacity));
  }
}

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

//color var(--w200)
@css {
  .body {
    color: rgb(var(--v-theme-on-surface));
  }
}

.body-left-slot
  grid-row-start 3

</style>