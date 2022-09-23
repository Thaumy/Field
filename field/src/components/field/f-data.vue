<template>

  <slot v-if="dataReady" v-bind="data"/>

</template>

<script lang="ts" setup>

import {onMounted, ref} from "vue"

const props = withDefaults(
    defineProps<{
      provider: () => Promise<any>
    }>(), {
      provider: () => Promise.resolve()
    })

const dataReady = ref(false)
const data = ref<any>(null)

props.provider().then(v => {
  data.value = v
  dataReady.value = true
})

</script>

<style lang="stylus" scoped>

</style>
