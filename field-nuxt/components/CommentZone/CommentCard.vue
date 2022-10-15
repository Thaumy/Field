<template>
  <div>

    <div class="comment-card"
         @mouseover="showReplyBtn()"
         @mouseleave="hideReplyBtn()"
    >
      <div class="avatar-zone">
        <v-avatar
            class="user-avatar"
            :class="userSiteUrl?'cursor-pointer':''"
            rounded="true"
            size="32"
            @click="blankUrl(userSiteUrl)"
        >
          <img :src="userAvatarUrl" alt="" style="width:100%"/>
        </v-avatar>
        <v-icon
            class="web-icon"
            icon="mdi-web"
            size="10"
            v-if="userSiteUrl"
        />
      </div>

      <div class="user-name-zone">
        <div class="flex align-self-end">
          <div class="user-name" v-text="userName"/>

          <transition name="reply-btn">
            <v-icon
                v-if="!disableReply"
                class="reply-btn ml-1"
                color="orange"
                icon="mdi-reply"
                size="1.1rem"
                v-show="replyBtnAlwaysOn||replyBtnVisibility"
                @click="$emit('replyClick')"
            />
          </transition>
        </div>

        <slot name="user-name-right-end-slot"/>
      </div>

      <div
          class="create-time"
          v-text="formatToDateTime(createTime)"
      />

      <div class="body">
        <slot name="body-top-slot"/>
        <f-text-render :text="body"/>
      </div>
    </div>

  </div>
</template>

<script setup lang="ts">

import {ref} from "vue"
import {formatToDateTime} from "@/scripts/util/time"
import FTextRender from "@/components/field/f-text-render.vue"

defineEmits<{
  (e: 'replyClick'): void
}>()

withDefaults(
    defineProps<{
      body: string,
      userName: string
      userSiteUrl: string | null,
      userAvatarUrl: string,
      createTime: Date,
      disableReply: boolean
    }>(), {
      userSiteUrl: null,
      disableReply: false,
    })

const replyBtnAlwaysOn = //when using mobile devices
    !/Windows|Mac|Linux/.test(navigator.userAgent)
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

  font-size 0.7rem
  color rgba(170 170 170 1)

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

  padding 4px

.body-left-slot
  grid-row-start 3

@css {
  .body {
    color: rgba(var(--v-theme-on-surface), 0.8);
  }
  .web-icon {
    color: rgb(var(--v-theme-primary));
  }
}

</style>