<template>
  <div>

    <div class="comment-editor"
    >
      <v-tabs :height=12>
        <v-tab>
          编辑
        </v-tab>
        <v-tab>
          预览
        </v-tab>
      </v-tabs>

      <div class="editor-header">
        <div/>
        <div class="tools">
          <v-icon color="grey" size="x-small" icon="mdi-format-header-3"/>
          <v-icon color="grey" size="x-small" icon="mdi-format-bold"/>
          <v-icon color="grey" size="x-small" icon="mdi-format-italic"/>
          <v-icon color="grey" size="x-small" icon="mdi-format-strikethrough"/>
          <v-icon color="grey" size="x-small" icon="mdi-format-quote-open"/>
          <v-icon color="grey" size="x-small" icon="mdi-code-tags"/>
          <v-icon color="grey" size="x-small" icon="mdi-format-list-checks"/>
          <v-icon color="grey" size="x-small" icon="mdi-format-list-bulleted"/>
          <v-icon color="grey" size="x-small" icon="mdi-format-list-numbered"/>
          <v-icon color="grey" size="x-small" icon="mdi-link-variant"/>
        </div>
      </div>
      <textarea class="body-input border-radius-all"/>
      <div class="editor-footer">
        <div/>
        <v-btn
            width="15%"
            class="commit-btn"
            :color="replyMode ?'orange':'#238636'"
            size="small"
        >
          {{ replyMode ? '回复' : '提交' }}
        </v-btn>
      </div>
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
.editor-header
  grid-row-start 1
  display flex
  justify-content space-between

.editor-footer
  grid-row-start 3
  display flex
  justify-content space-between

.tools
  > i
    margin-left 2px
    margin-right 2px

.comment-editor
  display grid
  grid-template-rows auto auto auto
  border-radius 2px
  padding 4px

.user-avatar
  margin 4px

.email-input
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

.body-input
  resize none
  background var(--b20)

  height 4rem

  color var(--w200)

  font-size 0.8rem
  text-align left

  padding-top 2px
  padding-left 4px
  padding-right 4px
  padding-bottom 2px

  grid-row-start 2

.commit-btn
  margin 4px
  grid-row-start 3
</style>