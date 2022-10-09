<template>
  <v-app>
    <v-main>

      <div class="transition-standard" :class="{hidden:!contentVisibility}">
        <MenuBar :items="menu_items"/>
        <div class="content">
          <Menu
              class="left-part"
              :items="menu_items"
          />
          <div class="right-part">
            <NuxtPage/>
            <!--
                  <router-view v-slot="{Component,route}">

                    <transition name="router-view">
                      <keep-alive>
                        <component :is="Component" :key="route.path"/>
                      </keep-alive>
                    </transition>

                  </router-view>
            -->
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
import {menu_items} from "@/scripts/data/menu"
import {useTheme} from "vuetify"
import {addRouteMiddleware, useAsyncData, useNuxtApp, useRoute, useRouter} from "#app"

const route = useRoute()
const router = useRouter()
const homePagePosition = ref(0)

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
  provide('showGlobalSnackbar', globalSnackbar.value.show)
})

const contentVisibility = ref(true)
const pageFootVisibility = ref(true)

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
