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
          v-slot="{tab}"
          :tabs="items"
      >
        <f-tab
            class="menu-tab"
            :title="tab.title"
            @click="$router.push(tab.route)"
        />
      </f-tabs>

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
import FTab from "@/components/field/f-tab.vue";

const props = defineProps({
  items: {
    type: Object as PropType<Tab[]>,
    default: []
  }
})

</script>

<style lang="stylus" scoped>

.menu-tab
  height 6vh
  max-height 44px
  min-height 28px
  letter-spacing 1px

</style>