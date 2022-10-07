<template>

  <div v-if="visibility">
    <slot/>
  </div>
  <div
      v-else
      class="holder"
      ref="holder"
  />

</template>

<script lang="ts" setup>

import {onMounted, ref} from "vue"

const props = withDefaults(
    defineProps<{
      //TODO custom transition class
      margin: number,
      initializer: () => Promise<any>
    }>(), {
      margin: 200,
      initializer: () => Promise.resolve()
    })

const holder = ref()
const visibility = ref(false)

function handler(
    entries: IntersectionObserverEntry[],
    observer: IntersectionObserver
) {
  entries.forEach(async entry => {//entry
        if (entry.intersectionRatio > 0) {
          observer.unobserve(holder.value)
          await props.initializer()
          visibility.value = true
        }
      }
  )
}

onMounted(() =>
    new IntersectionObserver(handler, {
      root: null,
      rootMargin: props.margin + 'px',
      threshold: [0, 1]
    }).observe(holder.value)
)

</script>

<style lang="stylus" scoped>

.holder
  height: 50vh

</style>
