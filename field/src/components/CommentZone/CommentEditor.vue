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
          reverse=""
          v-model="currentMode"
          style="grid-row-start: 2"
      >
        <v-window-item :eager=true>
          <!--TODO auto expand in vertical-->
          <f-textarea
              class="body-textarea"
              v-model="body"
              label="El Psy Kongroo."
          />
        </v-window-item>
        <v-window-item :eager=true>
          <f-text-render class="body-preview" :text="bodyRenderResult"/>
        </v-window-item>
      </v-window>

      <div class="editor-footer">
        <v-chip
            color="grey"
            size="small"
            variant="text"
            prepend-icon="mdi-language-markdown"
        >
          支持使用Markdown
        </v-chip>
        <v-btn
            width="15%"
            class="commit-btn transition-standard"
            :style=
                "replyMode?
                    {color:'black',background:'orange'}:
                    {color:'rgb(var(--v-theme-on-secondary))',background:'rgb(var(--v-theme-secondary))'}"
            size="small"
            :disabled="!body"
        >
          {{ replyMode ? '回复' : '提交' }}
        </v-btn>
      </div>
    </div>

  </div>
</template>

<script setup lang="ts">
import {defineProps, ref} from "vue";
import {Tab} from "@/components/field/type";
import {marked} from "marked"
import FTabs from "@/components/field/f-tabs.vue";
import FTextarea from "@/components/field/f-textarea.vue";
import FTextRender from "@/components/field/f-text-render.vue";

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

const bodyRenderResult = ref('')

function toggleMode(mode: Mode) {
  if (mode === Mode.Preview)
    bodyRenderResult.value = marked(body.value)

  currentMode.value = mode
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

.body-preview
  min-height 3rem
  padding 8px
  font-size 0.7rem

.body-textarea
  width 100%
  min-height 3rem
  max-height 80vh
  font-size 0.8rem

.commit-btn
  margin 4px
  grid-row-start 3

@css {
  .commit-btn > .v-btn__overlay {
    background: rgb(var(--v-theme-background));
    transition: inherit;
  }
}
</style>
