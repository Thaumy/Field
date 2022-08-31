<template>
  <div>

    <div class="body">
      <div class="text markdown-body"
           id='body_html'
           v-html="body"
           v-if="body"
      />

      <div class="bottom-slot">
        <slot name="bottom-slot"/>
      </div>
    </div>

  </div>
</template>

<script setup lang="ts">
import {onMounted, defineProps, PropType, toRefs} from "vue";
//import '@/styles/prism/light.css'
//import "@/styles/markdown/light.styl"
import '@/styles/prism/dark.css'
import "@/styles/markdown/dark.styl"
import Prism from 'prismjs'

const props = defineProps({
  body: String,
  createTime: Object as PropType<Date>,
  modifyTime: Object as PropType<Date>
})

onMounted(() => {
  const block = document.getElementById('body_html')
  Prism.highlightAll()
  if (block)
    Prism.highlightAllUnder(block)
})

</script>

<style lang="stylus" scoped>
.body
  padding 6px

@css {
  .body {
    background: rgb(var(--v-theme-surface));
  }
}

img
  border-top-left-radius 3px
  border-top-right-radius 3px
  margin-bottom -5px

.text
  padding 6px
  letter-spacing 1px
  word-break break-word

//color rgba(240 240 240 1.00)
@css {
  .text {
    color: rgb(var(--v-theme-on-surface));
  }
}

.bottom-slot
  display flex
  justify-content space-between

</style>