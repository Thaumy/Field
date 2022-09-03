<template>
  <div>

    <div
        v-html="text"
        class="text-render-zone"
        :class="genClass()"
        ref="textRenderZone"
    />

  </div>
</template>

<script lang="ts" setup>
//highlight theme
import '@/styles/prism/dark.css'
import '@/styles/prism/light.css'
//markdown theme
import "@/styles/markdown/dark.styl"
import "@/styles/markdown/light.styl"

import {queueTypeSet} from "@/scripts/mathjax/render"
import {useTheme} from "vuetify"
import Prism from 'prismjs'
import {onMounted, Ref, ref} from "vue";

defineProps({
  text: String
})

const textRenderZone: Ref<HTMLElement | null> = ref(null)
const theme = useTheme()

function genClass() {
  if (theme.global.current.value.dark)
    return "markdown-dark code-dark"
  else
    return "markdown-light code-light"
}

onMounted(() => {
  if (!textRenderZone.value)
    return

  Prism.highlightAllUnder(textRenderZone.value)
  queueTypeSet(textRenderZone.value)
})

</script>

<style lang="stylus" scoped>

.text-render-zone
  letter-spacing 0.5px
  word-break break-word

@css {
  .text-render-zone {
    color: rgb(var(--v-theme-on-surface));
  }
}

</style>