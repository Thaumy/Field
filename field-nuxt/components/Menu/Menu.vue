<template>
  <div>

    <f-card class="menu">
      <theme-toggle-btn
          class="position-absolute ma-1"
          style="opacity: 0.4"
      />
      <Avatar :avatar-url="avatar_img_url"/>
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
            @click="routerPush(tab.route)"
        />
      </f-tabs>

      <About info="Thaumy's Blog©2016-2023<br>About Site" v-ripple/>

    </f-card>

  </div>
</template>

<script lang="ts" setup>

import About from "./About.vue"
import Info from "./Info.vue"
import Avatar from "./Avatar.vue"
import {Tab} from "@/components/field/type"
import FTab from "@/components/field/f-tab.vue"
import FTabs from "@/components/field/f-tabs.vue"
import FCard from "@/components/field/f-card.vue"
import ThemeToggleBtn from "@/components/btn/ThemeToggleBtn.vue"
import {avatar_img_url} from "@/public/config/site"
import {useRouter, useRoute} from "#app"

const props = withDefaults(
    defineProps<{
      items: Tab[]
    }>(), {
      items: () => []
    })

const router = useRouter()
const route = useRoute()

function routerPush(to: string) {
  if (route.path !== to)
    router.push(to)
}

</script>

<style lang="stylus" scoped>

.menu-tab
  height 6vh
  max-height 44px
  min-height 28px
  letter-spacing 1px

</style>