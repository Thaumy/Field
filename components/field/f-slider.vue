<template>
  <div>

    <div class="f-slider" ref="slider">
      <div
          class="slot"
          :style="style"
          v-if="render"
      >
        <slot/>
      </div>
    </div>

  </div>
</template>

<script setup lang="ts">

import {ref} from "vue"

const props = withDefaults(
    defineProps<{
      afterClosed: () => void
    }>(), {
      afterClosed: () => {
      }
    })

const render = ref(false)
const style = ref<{ top: string, height: string, opacity: number }>()
const latestHeight = ref(0)
const slider = ref()

defineExpose({
  expand(height: number) {
    latestHeight.value = height
    style.value = {
      top: '-' + height + 'px',
      height: '0',
      opacity: 0
    }
    render.value = true
    requestAnimationFrame(() => {
      style.value = {
        top: '0',
        height: height + 'px',
        opacity: 1
      }
    })
  },
  close() {
    style.value = {
      top: '-' + latestHeight.value + 'px',
      height: '0',
      opacity: 0
    }
    setTimeout(() => {
      render.value = false
      props.afterClosed()
    }, 200)
  }
})

</script>

<style lang="stylus" scoped>

.f-slider
  overflow hidden

.slot
  position relative
  transition all 0.2s ease

</style>
