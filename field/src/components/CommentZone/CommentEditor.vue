<template>
  <div>

    <div class="comment-editor">

      <div class="editor-header">
        <f-tabs
            class="mode-tabs"
            :tabs="genTabs(body)"
            @tab-click="ev=>toggleMode(ev.mode)"
        />
        <div class="tools">
          <v-icon icon="mdi-format-header-3" @click="body+='### h3'"/>
          <v-icon icon="mdi-format-bold" @click="body+='**bold**'"/>
          <v-icon icon="mdi-format-italic" @click="body+='_italic_'"/>
          <v-icon icon="mdi-format-strikethrough" @click="body+='~lineThrough~'"/>
          <v-icon icon="mdi-format-quote-open" @click="body+='> reference'"/>
          <v-icon icon="mdi-code-tags" @click="body+='`code`'"/>
          <v-icon icon="mdi-format-list-checks" @click="body+=' [x] todo'"/>
          <v-icon icon="mdi-format-list-bulleted" @click="body+='- item'"/>
          <v-icon icon="mdi-format-list-numbered" @click="body+='1. item'"/>
          <v-icon icon="mdi-link-variant" @click="body+='[description](url)'"/>
        </div>
      </div>

      <v-window
          reverse=""
          v-model="currentMode"
          style="grid-row-start: 2"
      >
        <v-window-item :eager=true>
          <!--TODO auto expand in vertical-->
          <textarea
              class="body-input border-radius-all"
              placeholder="El Psy Kongroo."
              rows="3"
              v-model="body"
          />
        </v-window-item>
        <v-window-item :eager=true>
          <div class="body-preview markdown-body" ref="BodyPreview"/>
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
import {Tab} from "@/components/field/types";
import {marked} from "marked"
import FTabs from "@/components/field/f-tabs.vue";

defineProps({
  replyMode: {
    type: Boolean,
    default: false
  }
})

enum Mode {Edit = 0, Preview = 1}

const genTabs = (body: string) => [
  <Tab><unknown>{title: '编辑', mode: Mode.Edit},
  <Tab><unknown>{title: '预览', disabled: (body === ""), mode: Mode.Preview}
]

const body = ref("")
const currentMode = ref(Mode.Edit)

function toggleMode(mode: Mode) {
  if (mode === Mode.Preview)
    renderMarkdown()

  currentMode.value = mode
}

const BodyPreview = ref()

function renderMarkdown() {
  BodyPreview
      .value
      .innerHTML = marked(body.value)
}

/*
### h3

**bold**
_italic_
~~midline~~
`code`

> quote

- [x] ok

- item

1. item
2. item

[blog](https://www.thaumy.cn)
*/
</script>

<style lang="stylus" scoped>

.comment-editor
  display grid
  grid-template-rows auto auto auto
  border-radius 2px
  padding 4px
  padding-top 0

.mode-tabs
  margin-left 8px
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
  margin-right 2px

  > i
    color rgba(200, 200, 200, 0.8)
    font-size 1rem
    cursor pointer
    margin-left 2px
    margin-right 2px

.body-preview
  color var(--w200)
  min-height 3rem
  padding-left 8px
  padding-right 8px
  font-size 0.7rem

.body-input
  background var(--b20)
  width 100%

  display block
  min-height 3rem
  max-height 80vh

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