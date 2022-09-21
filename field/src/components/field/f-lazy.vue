<template>
  <div>

    <div ref="target">
      <transition-group name="initialized">
        <div v-if="visibility">
          <slot v-bind="data"/>
        </div>
        <div v-else style="height:50vh"/>
      </transition-group>
    </div>

  </div>
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
      initializer: async () => null
    })

const data = ref<any>(null)
const target = ref()
const visibility = ref(false)

onMounted(() => {
  const handler = (entries: IntersectionObserverEntry[]) => {
    entries.forEach(async entry => {//entry
          if (entry.intersectionRatio > 0) {
            data.value = await props.initializer()
            visibility.value = true
          }
        }
    )
  }

  new IntersectionObserver(handler, {
    root: null,
    rootMargin: props.margin + 'px',
    threshold: [0, 1]
  }).observe(target.value)
})

</script>

<style lang="stylus" scoped>

.initialized-enter-active
  transition all 0.4s ease

.initialized-enter-from
  transform translateX(50px) rotate(0.5deg)
  opacity 0

</style>