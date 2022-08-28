<template>
  <div>

    <f-vertical-tabs
        :tabs="tabs"
        :double-bar="doubleBar"
        @tab-click="t=>$emit('tabClick',t)"
        v-if="vertical"
    />

    <f-horizontal-tabs
        :tabs="tabs"
        :double-bar="doubleBar"
        @tab-click="t=>$emit('tabClick',t)"
        v-else
    />

  </div>
</template>

<script lang="ts" setup>
import {PropType} from "vue";
import {Tab} from "@/components/field/types";
import FHorizontalTabs from "@/components/field/f-horizontal-tabs.vue";
import FVerticalTabs from "@/components/field/f-vertical-tabs.vue";

defineEmits<{ (e: 'tabClick', tab: Tab): void }>()

defineProps({
  tabs: Object as PropType<Tab[]>,
  doubleBar: {
    type: Boolean,
    default: false
  },
  vertical: {
    type: Boolean,
    default: false
  }
})
</script>

<style lang="stylus" scoped>

</style>