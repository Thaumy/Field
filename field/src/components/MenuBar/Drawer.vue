<template>
  <transition name="drawer" tag="div">

    <div class="drawer" v-show="visibility">
      <div class="tab-list">
        <f-tabs double-bar vertical :tabs="tabs"/>
      </div>

      <div class="info cursor-pointer" @click="">
        Thaumy's Blog@2016-2023<br>
        About Site
      </div>
    </div>

  </transition>
</template>

<script lang="ts" setup>
import {defineProps, PropType} from "vue";
import {Tab} from "@/components/field/types";
import FTabs from "@/components/field/f-tabs.vue";

defineProps({
  tabs: {
    type: Object as PropType<Tab[]>,
    default: []
  },
  visibility: {
    type: Boolean,
    default: false
  }
})

</script>

<style lang="stylus" scoped>

.drawer
  left 0
  z-index 3
  padding-top 50px
  width 242px

  height 100%
  position fixed

  backdrop-filter saturate(180%) blur(20px)
  grid-template-rows 84% 16%

.tab-list
  margin-top 20px
  display grid

.info
  color: grey;
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