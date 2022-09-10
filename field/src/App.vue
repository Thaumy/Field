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
            <router-view
                v-slot="{Component,route}"
            >
              <transition name="router-view">
                <keep-alive>
                  <component :is="Component" :key="route.path"/>
                </keep-alive>
              </transition>
            </router-view>
          </div>
        </div>

        <FixedBtnZone/>

        <f-snackbar ref="globalSnackbar"/>
      </div>

      <PageFoot
          class="page-foot"
          body="基于pilipala构建 - Field Theme Designed By Thaumy<br>
              Thaumy'Blog 2016-2023<br>
              <a href='http://beian.miit.gov.cn/'
                 target='_blank'
                 style='color: rgba(255,255,255,0.6);
                        font-size: 0.7rem;
                        text-decoration: none;'
              >鲁ICP备2021005067</a>"
          v-if="pageFootVisibility"
          @fully-visible="contentVisibility=false"
          @fully-invisible="contentVisibility=true"
      />

    </v-main>
  </v-app>
</template>

<script lang="ts" setup>

import {onBeforeMount, onMounted, provide, ref} from 'vue'
import PageFoot from "@/components/common/PageFoot.vue"
import Menu from "@/components/Menu/Menu.vue"
import MenuBar from "@/components/MenuBar/MenuBar.vue"
import FixedBtnZone from "@/components/btn/FixedBtnZone.vue"
import {menu_items} from "@/scripts/data/menu"
import {useTheme} from "vuetify"
import {useRouter} from "vue-router"

onBeforeMount(() => {
  const theme = useTheme()
  const nowHour = new Date().getHours()
  //7-18点启用light主题
  theme.global.name.value =
      nowHour > 7 && nowHour < 18 ? 'fieldLight' : 'fieldDark'
})

const globalSnackbar = ref()

provide('isDarkTheme', useTheme().global.current.value.dark)
onMounted(() => {
  provide('showGlobalSnackbar', globalSnackbar.value.show)
})

const contentVisibility = ref(true)

const pageFootVisibility = ref(true)
const router = useRouter()
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
  margin-top 100px

.hidden
  opacity 0
  pointer-events none

.content
  margin auto
  max-width 1200px
  min-height 110vh
  display grid
  grid-template-columns 22% 7px auto

.router-view-leave-active
.router-view-enter-active
  transition all 0.4s ease

.router-view-enter-from
  transform translateX(50px) rotate(0.5deg)
  transform-origin 0 200vh

.router-view-leave-to
  transform scale(0.9)
  filter blur(100px)
  height 0
  opacity 0

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
