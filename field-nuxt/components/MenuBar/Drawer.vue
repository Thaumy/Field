<template>
  <transition name="drawer" tag="div">

    <div class="drawer" v-show="visibility">

      <div class="btn-zone position-absolute">
        <theme-toggle-btn
            class="ma-2"
            style="opacity: 0.8"
        />
      </div>

      <f-tabs
          class="menu-tabs"
          vertical
          double-bar
          router-binding
          :tabs="items"
          v-slot="{tab}"
      >
        <f-tab
            class="menu-tab"
            :title="tab.title"
            @click="$emit('tabClick');router.push(tab.route)"
        />
      </f-tabs>

      <div class="info cursor-pointer" v-html="info" @click="$emit('infoClick')"/>

    </div>

  </transition>
</template>

<script lang="ts" setup>

import {Tab} from "@/components/field/type"
import FTabs from "@/components/field/f-tabs.vue"
import ThemeToggleBtn from "@/components/btn/ThemeToggleBtn.vue"
import FTab from "@/components/field/f-tab.vue"
import {useRouter} from "#app"

const router = useRouter()

const emits = defineEmits<{
  (e: 'tabClick'): void,
  (e: 'infoClick'): void
}>()

const props = withDefaults(
    defineProps<{
      items: Tab[],
      visibility: boolean
      info: string
    }>(), {
      visibility: false
    })

</script>

<style lang="stylus" scoped>

.drawer
  width 242px
  height 100%

  left 0
  z-index 4
  position fixed
  grid-template-rows 86% 14%

  backdrop-filter saturate(200%) blur(24px)

@css {
  .drawer {
    background: rgba(var(--v-theme-background), 0.6);
  }
}

.menu-tabs
  padding-top 60px
  grid-row-start 1

.menu-tab
  height 6vh
  max-height 44px
  min-height 28px
  letter-spacing 1px

.info
  grid-row-start 2
  color grey
  width 88%
  text-align center
  margin auto
  font-size 0.6rem

.drawer-enter-from
.drawer-leave-to
  left -246px

.drawer-enter-to
.drawer-leave-from
  left 0

.drawer-enter-active
.drawer-leave-active
.drawer-enter-active
.drawer-leave-active
  transition all 0.2s ease

/* 屏幕宽度 [ 1001  + ) */
@media (min-width 1001px)
  .drawer
    display none

/* 屏幕宽度 ( -  1000 ] */
@media (max-width 1000px)
  .drawer
    display grid

</style>