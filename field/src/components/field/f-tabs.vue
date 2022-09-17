<template>
  <div>

    <div
        class="f-tabs"
        :class="{'f-tabs-vertical':vertical,
                 'f-tabs-horizontal':!vertical}"
    >

      <transition-group name="bars" v-if="vertical">
        <div
            class="bar"
            key=""
            style="grid-column-start:1"
            :style="{'grid-row-start':_barPosition+1}"
            v-if="_barPosition>=0"
        />
        <div
            class="bar"
            key=""
            style="grid-column-start:3"
            :style="{'grid-row-start':_barPosition+1}"
            v-if="doubleBar&&_barPosition>=0"
        />
      </transition-group>
      <transition-group name="bars" v-else>
        <div
            class="bar"
            key=""
            style="grid-row-start:1"
            :style="{'grid-column-start':_barPosition+1}"
            v-if="doubleBar&&_barPosition>=0"
        />
        <div
            class="bar"
            key=""
            style="grid-row-start:3"
            :style="{'grid-column-start':_barPosition+1}"
            v-if="_barPosition>=0"
        />
      </transition-group>

      <div
          :style="vertical?{'grid-column-start':2}:{'grid-row-start':2}"
          v-for="(tab,index) in tabs"
          @click="tab.disabled?()=>{}:moveBar(index)"
      >
        <slot :tab="tab"/>
      </div>
    </div>

  </div>
</template>

<script lang="ts" setup>

import {ref, watch} from "vue"
import {Tab} from "@/components/field/type"
import {useRoute} from "vue-router"

const props = withDefaults(
    defineProps<{
      tabs: Tab[],
      vertical: boolean,
      doubleBar: boolean,
      barPosition: number,
      routerBinding: boolean
    }>(), {
      vertical: false,
      doubleBar: false,
      barPosition: -1,
      routerBinding: false
    })

const _barPosition = ref(props.barPosition)

if (props.routerBinding) {
  let map: { [k: string]: number } = {}
  props.tabs.forEach((tab, index) => map[tab.route] = index)

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

function moveBar(to: number) {
  _barPosition.value = to
}

</script>

<style lang="stylus" scoped>

.f-tabs-vertical
  grid-template-columns 1% 98% 1%

.f-tabs-horizontal
  grid-template-rows 2px auto 2px

.f-tabs
  display grid

@css {
  .f-tabs .bar {
    background: rgb(var(--v-theme-primary));
  }
}

.bars-leave-to
  opacity 0

.bars-enter-from
  transform scaleY(0.5)

.bars-move
.bars-enter-active
.bars-leave-active
  transition all 0.2s ease

</style>
