<template>
  <div>

    <f-vertical-tabs
        :tabs="tabs"
        :double-bar="doubleBar"
        :bar-position="_barPosition"
        @tab-click="tabClickHandler"
        v-if="vertical"
    />

    <f-horizontal-tabs
        :tabs="tabs"
        :double-bar="doubleBar"
        :bar-position="_barPosition"
        @tab-click="tabClickHandler"
        v-else
    />

  </div>
</template>

<script lang="ts" setup>

import {computed, onBeforeMount, onMounted, PropType, Ref, ref, watch} from "vue"
import {Tab} from "@/components/field/type"
import FHorizontalTabs from "@/components/field/f-horizontal-tabs.vue"
import FVerticalTabs from "@/components/field/f-vertical-tabs.vue"
import {useRoute} from 'vue-router'

const emits = defineEmits<{
  (e: 'tabClick', tab: Tab): void
}>()

const props = defineProps({
  tabs: {
    type: Object as PropType<Tab[]>,
    default: []
  },
  routerBinding: {
    type: Boolean,
    default: false
  },
  doubleBar: {
    type: Boolean,
    default: false
  },
  vertical: {
    type: Boolean,
    default: false
  },
  barPosition: {
    type: Number,
    default: -1
  }
})

const _barPosition = ref(props.barPosition)

if (props.routerBinding) {
  let map: { [k: string]: number } = {}
  props.tabs?.forEach((tab, index) => map[tab.route] = index)

  function updateBarPosition(routePath: string) {
    const v = map[routePath]

    if (v >= 0)
      _barPosition.value = v
    else
      _barPosition.value = -1
  }

  const route = useRoute()
  updateBarPosition(route.path)
  watch(route, r => updateBarPosition(r.path))
}

function tabClickHandler(tab: Tab, index: number) {
  if (!tab.disabled) {
    emits('tabClick', tab)
    if (!props.routerBinding)
      _barPosition.value = index
  }
}

</script>

<style lang="stylus" scoped>

</style>