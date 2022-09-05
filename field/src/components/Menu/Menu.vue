<template>
  <div>

    <f-card class="menu">
      <theme-toggle-btn
          class="position-absolute ma-1"
          style="opacity: 0.4"
      />

      <Avatar avatarUrl="src/assets/pp512.png"/>

      <Info
          class="mb-4"
          title="THAUMY的小站"
          :typing="[
            '你好！~~^400',
            '这里是THAUMY的博客！^300',
            '又一个码农的家',
            '又一个码农的家.',
            '又一个码农的家..',
            '又一个码农的家...']"
      />

      <f-tabs
          vertical
          double-bar
          router-binding
          :tabs="tabs"
          @tab-click="(_tab)=>$router.push(_tab.route)"
      />

      <About info="Thaumy's Blog©2016-2023<br>About Site" v-ripple/>

    </f-card>

  </div>
</template>

<script lang="ts" setup>

import {defineProps, PropType, ref} from "vue"
import About from "./About.vue"
import Info from "./Info.vue"
import Avatar from "./Avatar.vue"
import FCard from "@/components/field/f-card.vue"
import FTabs from "@/components/field/f-tabs.vue"
import {Tab} from "@/components/field/type"
import ThemeToggleBtn from "@/components/btn/ThemeToggleBtn.vue"

const props = defineProps({
  tabs: {
    type: Object as PropType<Tab[]>,
    default: []
  }
})

</script>

<style lang="stylus" scoped>

</style>