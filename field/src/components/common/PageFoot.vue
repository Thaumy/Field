<template>
  <div>

    <!--Banishment<br>
    PixivID:75993030<br>-->

    <div class="holder" v-html="body" ref="pageFoot"/>

  </div>
</template>

<script lang="ts" setup>

import {ref, onMounted} from "vue"

const emits = defineEmits<{
  (e: 'fullyVisible'): void,
  (e: 'fullyInvisible'): void,
}>()

const props =
    defineProps<{
      body: string
    }>()

const pageFoot = ref()

onMounted(() => {
  const handler = (entries: IntersectionObserverEntry[]) => {
    entries.forEach(entry => {
      if (entry.intersectionRatio > 0.98)
        emits('fullyVisible')
      else if (entry.intersectionRatio < 0.02)
        emits('fullyInvisible')
    })
  }

  new IntersectionObserver(handler, {
    root: null,
    rootMargin: '0px',
    threshold: [0, 1]
  }).observe(pageFoot.value)
})
</script>

<style lang="stylus" scoped>

.holder
  color white
  text-align center
  letter-spacing 1px
  font-size 0.8rem

</style>