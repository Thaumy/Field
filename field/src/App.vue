<template>
  <v-app>

    <v-main>

      <MenuBar :posts="menu_posts" :style="commonOpacityStyle"/>

      <div class="content">
        <Menu
            class="left-part"
            :tabs="menu_tabs"
            :style="commonOpacityStyle"
        />

        <!--:style="commonOpacityStyle"-->
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

      <FixedBtnZone :style="commonOpacityStyle"/>

    </v-main>
    <!--
        <PageFoot
            body="基于pilipala构建 - Field Theme Designed By Thaumy<br>
                      Thaumy'Blog 2016-2023<br>
                      <a href='http://beian.miit.gov.cn/'
                         target='_blank'
                         style='color: rgba(255,255,255,0.6);
                                font-size: 0.7rem;
                                text-decoration: none;'
                      >鲁ICP备2021005067</a>"
            style="margin: 20px;margin-top:80vh"
            :style="pageFootOpacityStyle"
            @fully-visible="pageFootFullyVisible()"
            @fully-invisible="pageFootFullyInvisible()"
        />
    -->
  </v-app>
</template>

<script lang="ts" setup>
import {onBeforeMount, onMounted, ref} from 'vue'
import PageFoot from "@/components/common/PageFoot.vue"
import Menu from "@/components/Menu/Menu.vue"
import MenuBar from "@/components/MenuBar/MenuBar.vue"
import FixedBtnZone from "@/components/btn/FixedBtnZone.vue"
import {menu_tabs} from "@/scripts/data/menu"
import {useTheme} from "vuetify"

onBeforeMount(() => {
  const theme = useTheme()
  const nowHour = new Date().getHours()
  //7-18点启用light主题
  theme.global.name.value =
      nowHour > 7 && nowHour < 18 ? 'fieldLight' : 'fieldDark'
})

const commonOpacityStyle = ref({
  opacity: 1,
  'pointer-events': 'unset',
  transition: 'all 0.2s ease'
})

const pageFootOpacityStyle = ref({
  opacity: 1,
  'pointer-events': 'none',
  transition: 'all 0.2s ease'
})

function pageFootFullyVisible() {
  commonOpacityStyle.value.opacity = 0
  commonOpacityStyle.value["pointer-events"] = 'none'
  pageFootOpacityStyle.value.opacity = 1
  pageFootOpacityStyle.value["pointer-events"] = 'unset'
}

function pageFootFullyInvisible() {
  commonOpacityStyle.value.opacity = 1
  commonOpacityStyle.value["pointer-events"] = 'unset'
  pageFootOpacityStyle.value.opacity = 0
  pageFootOpacityStyle.value["pointer-events"] = 'none'
}
</script>

<style lang="stylus" scoped>

.content
  margin auto
  max-width 1200px
  display grid
  grid-template-columns 22% 7px auto

.router-view-enter-from
  transform translateX(50px) rotate(1deg)
  transform-origin 0 400vh

.router-view-leave-active
.router-view-enter-active
  transition all 0.3s ease

//transition all 0.5s ease

.router-view-leave-to
  transform translateX(30px) translateY(30px)
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
