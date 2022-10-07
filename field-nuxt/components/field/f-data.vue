<template>

  <slot v-if="data!==null" v-bind="data"/>

</template>

<script lang="ts" setup>

import {onBeforeMount, onMounted, ref} from "vue"

const props = withDefaults(
    defineProps<{
      provider: () => Promise<any>
    }>(), {
      provider: () => Promise.resolve(null)
    })
const data = ref(null)
onBeforeMount(async () => {
  data.value = await props.provider()
})

</script>

<style lang="stylus" scoped>

</style>
