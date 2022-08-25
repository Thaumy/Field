<template>
  <div>

    <div class="comment-editor">

      <div class="editor-header">
        <f-horizontal-tabs
            class="mode-tabs"
            :tabs="[{title:'编辑',mode:Mode.Edit},{title:'预览',mode:Mode.Preview}]"
            @tab-click="(ev)=>this.mode=ev.mode"
        />
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

      <v-window v-model="mode" style="grid-row-start: 2" reverse="">
        <v-window-item>
          <textarea class="body-input border-radius-all" rows="3"/>
        </v-window-item>
        <v-window-item>
          <div style="height: 200px;background:green"></div>
        </v-window-item>
      </v-window>

      <div class="editor-footer">
        <v-chip color="grey"
                size="small"
                variant="text"
                prepend-icon="mdi-language-markdown"
        >
          支持使用Markdown
        </v-chip>
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
import FHorizontalTabs from "@/components/field/f-horizontal-tabs.vue";

defineProps({
  replyMode: {
    type: Boolean,
    default: false
  }
})

enum Mode {Edit = 0, Preview = 1}

const mode = ref(Mode.Edit)

</script>

<style lang="stylus" scoped>
.mode-tabs
  margin-left 4px
  align-self end

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
  background var(--b20)
  width 100%

  display block
  min-height 3rem

  color var(--w200)

  font-size 0.8rem
  text-align left

  padding 4px
  padding-left 6px
  padding-right 6px

.commit-btn
  margin 4px
  grid-row-start 3

</style>