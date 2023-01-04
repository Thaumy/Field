<template>
  <div>

    <f-card class="menu">
      <theme-toggle-btn
          class="position-absolute ma-1"
          style="opacity: 0.4"
      />
      <Avatar
          :about_me_post_id="about_me_post_id"
          :avatar-url="build_meta.avatarImgUrl"
      />
      <Info
          class="mb-4"
          :title=build_meta.siteTitle
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
          :tabs="tabs"
      >
        <f-tab
            class="menu-tab"
            :title="tab.title"
            @click="routerPush(tab.route)"
        />
      </f-tabs>

      <About
          v-ripple
          :about_site_post_id="about_site_post_id"
          info="Thaumy's Blog©2016-2023<br>About Site"
      />

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
import build_meta from "~/field.meta"
import {useRouter, useRoute} from "#app"

const props =
    defineProps<{
      about_me_post_id: string,
      about_site_post_id: string
      tabs: Tab[]
    }>()

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