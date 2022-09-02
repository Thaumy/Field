<template>
  <transition name="drawer" tag="div">

    <div class="drawer" v-show="visibility">

      <div class="btn-zone position-absolute">
        <theme-toggle-btn
            class="ma-2"
            style="opacity: 0.8"
        />
      </div>

      <div class="tab-list">
        <f-tabs double-bar vertical :tabs="tabs"/>
      </div>

      <div class="info cursor-pointer" v-html="info" @click=""/>

    </div>

  </transition>
</template>

<script lang="ts" setup>
import {defineProps, PropType} from "vue";
import {Tab} from "@/components/field/type";
import FTabs from "@/components/field/f-tabs.vue";
import ThemeToggleBtn from "@/components/btn/ThemeToggleBtn.vue";

defineProps({
  tabs: {
    type: Object as PropType<Tab[]>,
    default: []
  },
  visibility: {
    type: Boolean,
    default: false
  },
  info: String
})

</script>

<style lang="stylus" scoped>

.drawer
  z-index 3

  width 242px
  height 100%

  left 0
  position fixed
  grid-template-rows 86% 14%

  backdrop-filter saturate(180%) blur(20px)

@css {
  .drawer {
    background: rgba(var(--v-theme-background), var(--v-medium-emphasis-opacity));
  }
}

.tab-list
  padding-top 60px
  grid-row-start 1
  display grid

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