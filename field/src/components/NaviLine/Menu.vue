<template>
  <div>

    <div class="menu">
      <div class="tab-list">
        <f-tabs :tabs="pages"/>
      </div>

      <div class="info cursor-pointer" @click="">
        Thaumy的博客©2016-2023保留所有权利<br>
        基于pilipala构建<br>
        Field Theme Designed By Thaumy<br>
      </div>
    </div>

  </div>
</template>

<script lang="ts" setup>
import {defineProps, PropType} from "vue";
import {Page} from "@/scripts/common";
import FTabs from "@/components/field/f-vertical-tabs.vue";

defineProps({
  pages: Object as PropType<Page[]>
})
</script>

<style lang="stylus" scoped>

.menu
  z-index 10
  padding-top 50px
  width 246px

  height 100%
  position fixed

  backdrop-filter saturate(180%) blur(20px)
  grid-template-rows 84% 16%

.tab-list
  margin-top 20px
  display grid

.info
  width 88%
  text-align center

  margin auto

  font-size 11px
  line-height 16px

/* 屏幕宽度 [ 1001  + ) */
@media (min-width 1001px)
  .menu
    display none

/* 屏幕宽度 ( -  1000 ] */
@media (max-width 1000px)
  .menu
    display grid

</style>