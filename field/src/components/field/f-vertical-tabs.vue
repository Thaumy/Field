<template>
  <div>

    <div class="tab-list">
      <transition-group name="bar">
        <div class="bar"
             key="bar"
             style="grid-column-start:1"
             :style="{'grid-row-start':barPosition}"
        />
        <div class="bar"
             key="bar"
             style="grid-column-start:3"
             :style="{'grid-row-start':barPosition}"
             v-if="doubleBar"
        />
      </transition-group>

      <transition-group name="tab">
        <div
            class="tab"
            v-for="(tab,index) in tabs"
            :style="{'grid-row-start':index+1,
                      color:tab.disabled?'grey':'',
                      cursor:tab.disabled?'default':'pointer'}"
            :title="tab.title"
            :key="tab"
            v-ripple
            v-ripple.stop="!tab.disabled"
            @click="tabClick(tab,index)"
        >
          <div class="tab-title">{{ tab.title }}</div>
        </div>
      </transition-group>
    </div>

  </div>
</template>

<script lang="ts" setup>
import {ref, defineProps, PropType} from "vue";
import {Tab} from "@/components/field/types";

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
.tab-list
  display grid
  padding-bottom 8px
  grid-template-columns 1% 98% 1%

.bar
  margin-top 2px
  margin-bottom 2px
  background rgba(1, 153, 255, 1)

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
  transform scaleY(0.1)

.bar-leave-active
  position absolute

.tab
  display flex
  width 100%
  height 5vh
  max-height 44px
  min-height 28px

  margin auto
  padding-top 2px
  padding-bottom 2px
  margin-top 2px
  margin-bottom 2px
  grid-column-start 2

  letter-spacing 1px
  color rgba(230 230 230 1.00)

.tab-title
  margin-right auto
  align-self center
  margin-left auto
</style>
