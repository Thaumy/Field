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
import '@/styles/prism.css'
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

<style lang="stylus">
@import '@/styles/dark/markdown-dark.css'
</style>

<style lang="stylus" scoped>
.body
  padding 6px
  background rgb(30 30 30)

img
  border-top-left-radius 3px
  border-top-right-radius 3px
  margin-bottom -5px

.text
  /* 颜色模式 */
  color rgba(240 240 240 1.00)
  padding 6px

  font-size 15px
  line-height 22px
  letter-spacing 1px
  word-break break-word

.bottom-slot
  display flex
  justify-content space-between

</style>