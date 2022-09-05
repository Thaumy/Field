<template>
  <div>

    <div class="tab-list">
      <transition-group name="bar">
        <div
            class="bar"
            key=""
            style="grid-column-start:1"
            :style="{'grid-row-start':barPosition+1}"
            v-if="barPosition>=0"
        />
        <div
            class="bar"
            key=""
            style="grid-column-start:3"
            :style="{'grid-row-start':barPosition+1}"
            v-if="doubleBar&&barPosition>=0"
        />
      </transition-group>

      <transition-group name="tab">
        <div
            class="tab"
            v-for="(tab,index) in tabs"
            :key="tab"
            v-ripple
            v-ripple.stop="!tab.disabled"
            :style="{'grid-row-start':index+1,
                      color:tab.disabled?'grey':'',
                      cursor:tab.disabled?'default':'pointer'}"
            @click="$emit('tabClick',tab,index)"
        >
          <div class="tab-title">{{ tab.title }}</div>
        </div>
      </transition-group>
    </div>

  </div>
</template>

<script lang="ts" setup>

import {ref, defineProps, PropType, watch} from "vue"
import {Tab} from "@/components/field/type"

const emits = defineEmits<{
  (e: 'tabClick', tab: Tab, index: number): void
}>()

const props = defineProps({
  tabs: Object as PropType<Tab[]>,
  doubleBar: Boolean,
  barPosition: Number
})

</script>

<style lang="stylus" scoped>

.tab-list
  display grid
  padding-bottom 8px
  grid-template-columns 1% 98% 1%

.bar
  margin-top 2px
  margin-bottom 2px

@css {
  .bar {
    background: rgb(var(--v-theme-primary));
  }
}

.tab-enter-from
.tab-leave-to
.bar-leave-to
  opacity 0

.bar-enter-from
  transform scaleY(0.5)

.tab-move
.tab-enter-active
.tab-leave-active
.bar-move
.bar-enter-active
.bar-leave-active
  transition all 0.2s ease

.tab
  display flex
  width 100%
  height 6vh
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

@css {
  .tab-title {
    color: rgb(var(--v-theme-on-surface));
  }
}

</style>
