<template>
  <div>

    <div class="tab-list">
      <transition-group name="bar">
        <div
            class="bar"
            key=""
            style="grid-row-start:1"
            :style="{'grid-column-start':barPosition+1}"
            v-if="doubleBar&&barPosition>=0"
        />
        <div
            class="bar"
            key=""
            style="grid-row-start:3"
            :style="{'grid-column-start':barPosition+1}"
            v-if="barPosition>=0"
        />
      </transition-group>

      <transition-group name="tab">
        <div
            class="tab"
            v-for="(tab,index) in tabs"
            :key="tab"
            v-ripple
            v-ripple.stop="!tab.disabled"
            :style="{'grid-column-start':index+1,
                      color:tab.disabled?'grey':'',
                      cursor:tab.disabled?'default':'pointer'}"
            @click="$emit('tabClick',tab,index)"
        >
          {{ tab.title }}
        </div>
      </transition-group>
    </div>

  </div>
</template>

<script lang="ts" setup>

import {ref, defineProps, PropType, onMounted} from "vue"
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

.tab
  font-size 0.8rem
  padding-top 2px
  padding-left 4px
  padding-right 4px
  margin-left 2px
  margin-right 2px
  grid-row-start 2

@css {
  .tab {
    color: rgb(var(--v-theme-on-surface));
  }
}

.tab-list
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

.tab-enter-from
.tab-leave-to
.bar-leave-to
  opacity 0

.bar-enter-from
  transform scaleX(0.5)

.tab-move
.tab-enter-active
.tab-leave-active
.bar-move
.bar-enter-active
.bar-leave-active
  transition all 0.2s ease

</style>