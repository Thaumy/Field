<template>
  <div>

    <div
        class="text-render-zone markdown-zone code-zone transition-standard"
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

.text-render-zone
  letter-spacing 0.5px
  word-break break-word

</style>