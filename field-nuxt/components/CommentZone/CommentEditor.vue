<template>
  <div>

    <div class="comment-editor">

      <div class="header">

        <f-tabs
            v-slot="{tab}"
            class="mode-tabs"
            :tabs="modeTabs()"
            :bar-position="currentMode"
        >
          <f-tab
              class="mode-tab"
              :title="tab.title"
              :disabled="tab.disabled"
              @click="toggleMode(tab.mode)"
          />
        </f-tabs>

        <div class="tools">
          <v-icon icon="mdi-format-bold" @click="body+='**bold**'"/>
          <v-icon icon="mdi-format-italic" @click="body+='_italic_'"/>
          <v-icon icon="mdi-format-strikethrough" @click="body+='~lineThrough~'"/>
          <v-icon icon="mdi-format-quote-open" @click="body+='\n> reference'"/>
          <v-icon icon="mdi-code-tags" @click="body+='`code`'"/>
          <v-icon icon="mdi-format-list-checks" @click="body+='\n [x] todo'"/>
          <v-icon icon="mdi-format-list-bulleted" @click="body+='\n- item'"/>
          <v-icon icon="mdi-format-list-numbered" @click="body+='\n1. item'"/>
          <v-icon icon="mdi-link-variant" @click="body+='[description](url)'"/>
        </div>
      </div>

      <v-window
          class="body"
          theme=""
          reverse=""
          v-model="currentMode"
          style="grid-row-start: 2"
      >
        <v-window-item :eager=true>
          <!--TODO auto expand in vertical-->
          <f-textarea
              class="textarea"
              v-model="body"
              label="El Psy Kongroo."
          />
        </v-window-item>
        <v-window-item :eager=true>
          <f-text-render
              class="preview"
              :text="bodyRenderResult"
          />
        </v-window-item>
      </v-window>

      <div class="footer">
        <v-chip
            v-bind="props"
            color="grey"
            size="small"
            variant="text"
            style="margin-right:auto;align-self:center"
            prepend-icon="mdi-language-markdown"
        >
          支持使用Markdown
        </v-chip>
        <f-btn
            width="100%"
            class="commit-btn transition-standard"
            :disabled="!body"
            :warning="isReply"
            :text="isReply ? '回复' : '提交'"
            @click="$emit('createComment',body)"
            @disable-click="showGlobalSnackbar('mdi-tooltip-edit','填写评论内容是必要的','red')"
        />
      </div>
    </div>

  </div>
</template>

<script setup lang="ts">

import {inject, ref} from "vue"
import {Tab} from "@/components/field/type"
import {marked} from "marked"
import FBtn from "@/components/field/f-btn.vue"
import FTab from "@/components/field/f-tab.vue"
import FTabs from "@/components/field/f-tabs.vue"
import FTextRender from "@/components/field/f-divider.vue"
import FTextarea from "@/components/field/f-textarea.vue"

enum Mode {Edit = 0, Preview = 1}

const props =
    defineProps<{
      isReply: boolean,
    }>()

defineEmits<{
  (e: 'createComment'): void
}>()

const body = ref("")
const currentMode = ref(Mode.Edit)
const bodyRenderResult = ref("")

defineExpose({
  reset() {
    body.value = ""
    currentMode.value = Mode.Edit
    bodyRenderResult.value = ""
  }
})

const showGlobalSnackbar = inject('showGlobalSnackbar')

const modeTabs = () => [
  <Tab><unknown>{title: '编辑', mode: Mode.Edit},
  <Tab><unknown>{title: '预览', mode: Mode.Preview, disabled: (body.value === '')}
]

function toggleMode(mode: Mode) {
  if (mode === Mode.Preview)
    bodyRenderResult.value = marked(body.value)

  currentMode.value = mode
}

</script>

<style lang="stylus" scoped>

.comment-editor
  display grid
  grid-template-rows auto auto auto
  border-radius 2px
  padding 4px
  padding-bottom 0

  > [class~=header]
    grid-row-start 1
    display flex
    justify-content space-between

  > [class~=footer]
    grid-row-start 3
    display flex
    justify-content end

  > [class~=body]
    [class~=preview]
      min-height 3rem
      padding 8px
      font-size 0.7rem

    [class~=textarea]
      width 100%
      min-height 3rem
      max-height 80vh
      font-size 0.8rem

.mode-tabs
  margin-left 8px
  align-self end

.mode-tab
  font-size 0.9rem
  margin-left 4px
  margin-right 4px

.tools
  margin-right 2px

  > i
    font-size 1rem
    cursor pointer
    margin-left 2px
    margin-right 2px

//color rgba(200, 200, 200, 0.8)
@css {
  .tools > i {
    color: rgba(var(--v-theme-on-surface), var(--v-medium-emphasis-opacity));
  }
}

.commit-btn
  width 15%
  margin 4px
  grid-row-start 3

@css {
  .commit-btn > .v-btn__overlay {
    background: rgb(var(--v-theme-background));
    transition: inherit;
  }
}
</style>
