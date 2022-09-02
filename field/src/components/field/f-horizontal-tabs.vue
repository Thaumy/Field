<template>
  <div>

    <div class="f-horizontal-tabs">
      <transition-group name="bar">
        <div
            class="bar"
            key="bar"
            style="grid-row-start: 1"
            :style="{'grid-column-start':barPosition}"
            v-if="doubleBar"
        />
        <div
            class="bar"
            key="bar"
            style="grid-row-start: 3"
            :style="{'grid-column-start':barPosition}"
        />
      </transition-group>

      <transition-group name="tab">
        <div
            class="tab"
            v-for="(tab,index) in tabs"
            v-ripple
            v-ripple.stop="!tab.disabled"
            style="grid-row-start: 2"
            :style="{'grid-column-start':index+1,
                      color:tab.disabled?'grey':'',
                      cursor:tab.disabled?'default':'pointer'}"
            @click="tabClick(tab,index)"
        >
          {{ tab.title }}
        </div>
      </transition-group>
    </div>

  </div>
</template>

<script lang="ts" setup>
import {ref, defineProps, PropType} from "vue";
import {Tab} from "@/components/field/type";

const emits = defineEmits<{ (e: 'tabClick', tab: Tab): void }>()

const props = defineProps({
  tabs: Object as PropType<Tab[]>,
  doubleBar: {
    type: Boolean,
    default: false
  }
})

const barPosition = ref(1)

function tabClick(tab: Tab, index: number) {
  if (tab.disabled)
    return

  emits('tabClick', tab)
  barPosition.value = index + 1//toggleBar
}
</script>

<style lang="stylus" scoped>

.tab
  font-size 0.8rem
  padding-top 2px
  padding-left 4px
  padding-right 4px
  margin-left 2px
  margin-right 2px

@css {
  .tab {
    color: rgb(var(--v-theme-on-surface));
  }
}

.f-horizontal-tabs
  display grid

.bar
  margin-left 2px
  margin-right 2px
  height 2px
  background rgba(1, 153, 255, 1)

@css {
  .bar {
    background: rgb(var(--v-theme-primary));
  }
}

.tab-move
.tab-enter-active
.tab-leave-active
.bar-move
.bar-enter-active
.bar-leave-active
  transition all 0.2s ease

.tab-enter-from
.tab-leave-to
.bar-enter-from
.bar-leave-to
  opacity 0

.bar-enter-from
.bar-leave-to
  transform scaleX(0.1)

</style>