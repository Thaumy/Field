<template>
  <v-app>
    <v-main>

      <div class="transition-standard" :class="{hidden:!contentVisibility}">
        <MenuBar
            :about_me_post_id="about_me_post_id"
            :about_site_post_id="about_site_post_id"
            :tabs="menu_tabs"
        />
        <div class="content">
          <Menu
              class="left-part"
              :about_me_post_id="about_me_post_id"
              :about_site_post_id="about_site_post_id"
              :tabs="menu_tabs"
          />
          <div class="right-part">
            <NuxtPage/>
          </div>
        </div>

        <FixedBtnZone/>
        <f-snackbar ref="globalSnackbar"/>
      </div>
    </v-main>
  </v-app>

</template>

<script lang="ts" setup>

import Menu from "@/components/Menu/Menu.vue"
import MenuBar from "@/components/MenuBar/MenuBar.vue"
import FSnackbar from "@/components/field/f-snackbar.vue"
import {onBeforeMount, onMounted, provide, ref} from 'vue'
import PageFoot from "@/components/common/PageFoot.vue"
import FixedBtnZone from "@/components/common/FixedBtnZone.vue"
import {useTheme} from "vuetify"
import {addRouteMiddleware, useAsyncData, useNuxtApp, useRoute, useRouter, useState} from "#app"
import {Tab} from "~/components/field/type"

const route = useRoute()
const router = useRouter()
const homePagePosition = ref(0)
const nuxtApp = useNuxtApp()

addRouteMiddleware(async (to, from) => {
  /*
  if (from.path === '/') {
    homePagePosition.value = document.documentElement.scrollTop
  }
  if (to.path === '/')
    window.scrollTo({top: homePagePosition.value, behavior: 'smooth'})
  else
    window.scrollTo({top: 0, behavior: 'smooth'})
  */
  if (process.client)
    window.scrollTo({top: 0, behavior: 'smooth'})
  return true
})

onBeforeMount(() => {
  provide('isDarkTheme', useTheme().global.current.value.dark)
})

const globalSnackbar = ref()

onMounted(() => {
  provide('showGlobalSnackbar',
      (icon: string, msg: string, color: string, time: number) =>
          globalSnackbar.value.show(icon, msg, color, time))
})

const contentVisibility = ref(true)
const pageFootVisibility = ref(true)

const menu_posts = await (async () => {
  const {handler: getMenuPosts} = await (async () => {
    if (process.server)
      return import("@/ws/server/api/post/get_menu/handler")
    else
      return import("@/ws/client/api/post/get_menu/handler")
  })()
  const posts = await getMenuPosts({})
  if (posts.Ok) {
    return posts.Data.Collection
  } else {
    return []
  }
})()

for (const post of menu_posts)
  useState(`post:${post.Id}`, () => post)

const menu_tabs = (() => {
  let tabs: Tab[] = []
  tabs.push({title: "首页", disabled: false, route: "/"})
  for (let post of menu_posts)
    if (post.Mark === "menu")
      tabs.push({title: post.Title, disabled: false, route: "/" + post.Id})
  return tabs
})()

const about_me_post_id = menu_posts.find(x => x.Mark === "about_me")!.Id
const about_site_post_id = menu_posts.find(x => x.Mark === "about_site")!.Id

router.beforeEach(() => {
  pageFootVisibility.value = false
})

router.afterEach(() => {
  setTimeout(() => {
    pageFootVisibility.value = true
  }, 500)
})

</script>

<style lang="stylus" scoped>

.page-foot
  margin 20px
  margin-top 200px

.hidden
  opacity 0
  pointer-events none

.content
  margin auto
  max-width 1200px
  min-height 110vh
  display grid
  //TODO 以这种方式实现的中间间隔并不优雅
  grid-template-columns 22% 0.7% 77.3%

/* 屏幕宽度 [ 1001  + ) */
@media (min-width 1001px)
  .content
    padding-top 8px
    width 100%

/* 屏幕宽度 [ 601  1000 ] */
@media (min-width 601px) and (max-width 1000px)
  .content
    padding 7px
    padding-top 57px

/* 屏幕宽度 ( -  600 ] */
@media (max-width 600px)
  .content
    padding-top 57px

/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px)
  .right-part
    width 100%
    grid-column-start 3
    grid-column-end 4

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px)
  .right-part
    width 100%
    grid-column-start 1
    grid-column-end 4

/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px)
  .left-part
    width 22%
    max-width 264px //1200*0.22
    position fixed

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px)
  .left-part
    display none

</style>
