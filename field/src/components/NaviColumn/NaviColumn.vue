<template>
  <div>

    <f-card class="navi-card">

      <AvatarBox
          avatar="/pp512.png"
          title="THAUMY的小站"
      />

      <f-tabs :tabs="pages"/>

      <CoBox body=
                 'Thaumy的博客©2016-2020保留所有权利<br>
                基于pilipala构建<br>
                Field Theme Designed By Thaumy<br>'/>
    </f-card>

  </div>
</template>

<script lang="ts" setup>
import {defineProps, PropType, ref} from "vue";
import CoBox from "./CoBox.vue";
import AvatarBox from "./AvatarBox.vue";
import {Page} from "@/scripts/common";
import FCard from "@/components/field/f-card.vue";
import FTabs from "@/components/field/f-tabs.vue";

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