<template>
  <div>

    <div class="comment-editor"
    >
      <v-avatar
          class="user-avatar"
          rounded="true"
          size="32"
      >
        <v-img :src="avatar" cover="true"/>
      </v-avatar>
      <input class="user-name-input border-radius-all"/>
      <input class="email-input border-radius-all"/>
      <textarea class="body-input border-radius-all"></textarea>
      <v-switch
          class="preview-switch"
          v-model="previewMode"
          color="blue"
          @click="previewMode=!previewMode"
      >
        {{ previewMode ? '编辑' : '预览' }}
      </v-switch>
      <v-btn
          class="commit-btn"
          :color="replyMode ?'orange':'#238636'"
          size="small"
      >
        {{ replyMode ? '回复' : '提交' }}
      </v-btn>
    </div>

  </div>
</template>

<script setup lang="ts">
import {defineProps, ref} from "vue";

defineProps({
  replyMode: {
    type: Boolean,
    default: false
  }
})

const previewMode = ref(false)
const avatar = new URL('../../assets/comment_user_avatars/kurumi.jpg', import.meta.url).href

</script>

<style lang="stylus" scoped>
.comment-editor
  display grid
  grid-template-columns 40px 20% auto 100px 100px
  grid-template-rows auto auto auto
  border-radius 2px
  padding 4px

.user-avatar
  margin 4px

.user-name-input
  resize none
  height 1.5rem
  align-self center

  padding-left 4px
  padding-right 4px

  background var(--b20)
  color var(--w220)
  margin 4px
  font-size 0.7rem
  overflow hidden
  text-overflow ellipsis
  white-space nowrap

  grid-column-start 2

.body-input
  resize none
  background var(--b20)

  margin-left 4px
  margin-right 2px
  height 4rem

  color var(--w200)

  grid-row-start 2
  grid-column-start 2
  grid-column-end 6

  font-size 0.8rem
  text-align left

  padding-top 2px
  padding-left 4px
  padding-right 4px
  padding-bottom 2px

.preview-switch
  margin 4px
  height 10px
  grid-row-start 3
  grid-column-start 4

.commit-btn
  margin 4px
  grid-row-start 3
  grid-column-start 5
</style>