<template>
  <div>

    <div
        class="markdown-zone code-zone transition-standard"
        ref="textRenderZone"
        v-html="text"
    />

  </div>
</template>

<script lang="ts" setup>

import {queueTypeSet} from "@/scripts/mathjax/render"
import {onMounted, Ref, ref, watch} from "vue"
import {useTheme} from "vuetify"
import Prism from 'prismjs'

const props =
    defineProps<{
      text: string
    }>()

const textRenderZone = ref()
const theme = useTheme()

onMounted(() => {
  if (!textRenderZone.value)
    return

  Prism.highlightAllUnder(textRenderZone.value)
  queueTypeSet(textRenderZone.value)
})

</script>

<style lang="stylus" scoped>

</style>