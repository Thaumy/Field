<template>
  <div>

    <f-card class="navi-card">

      <Avatar avatar="/pp512.png"/>

      <Info
          title="THAUMY的小站"
          :typing="[
            '你好！~~^400',
            '这里是THAUMY的博客！^300',
            '又一个码农的家',
            '又一个码农的家.',
            '又一个码农的家..',
            '又一个码农的家...']"
      />

      <f-tabs :tabs="pages"/>

      <About info="Thaumy's Blog©2016-2023<br>About Site"/>
    </f-card>

  </div>
</template>

<script lang="ts" setup>
import {defineProps, PropType, ref} from "vue";
import About from "./About.vue";
import Info from "./Info.vue";
import Avatar from "./Avatar.vue";
import {Page} from "@/scripts/common";
import FCard from "@/components/field/f-card.vue";
import FTabs from "@/components/field/f-vertical-tabs.vue";

const props = defineProps({
  pages: Object as PropType<Page[]>
})
</script>

<style lang="stylus" scoped>
.navi-card
  color rgba(230 230 230 1.00)

/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px)
  .navi-card
    width 23%
    min-width 230px
    max-width 270px
    position fixed

/* 屏幕宽度 ( - , 1000 ] */
@media screen and (max-width: 1000px)
  .navi-card
    display none

</style>