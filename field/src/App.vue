<template>
  <v-app class="main">

    <v-main>

      <MenuBar :posts="menu_posts" :style="commonOpacityStyle"/>

      <div class="content">
        <Menu
            class="left-part"
            :posts="menu_posts"
            :style="commonOpacityStyle"
        />

        <router-view v-slot="{ Component }" class="right-part float-right">
          <transition name="router-view">
            <component :is="Component"/>
          </transition>
        </router-view>

        <!--
            :data-collection="post_data"
        <PostZone
            class="right-part float-right"
            :data-collection="[post_data[4]]"
            :style="commonOpacityStyle"
        />
        -->
      </div>

      <FixedBtnZone :style="commonOpacityStyle"/>

    </v-main>

    <PageFoot
        id="page-foot"
        body="基于pilipala构建 - Field Theme Designed By Thaumy<br>
              Thaumy'Blog 2016-2023<br>
              <a href='http://beian.miit.gov.cn/'
                 target='_blank'
                 style='color: rgba(255,255,255,0.6);
                        font-size: 0.7rem;
                        text-decoration: none;'
              >鲁ICP备2021005067</a>"
        style="margin: 20px;margin-top: 80px"
        :style="pageFootOpacityStyle"
    />

  </v-app>
</template>

<script lang="ts" setup>
import {onMounted, ref} from 'vue'
import GoUpBtn from "@/components/btn/GoUpBtn.vue";
import PageFoot from "@/components/common/PageFoot.vue";
import {Post} from "@/scripts/type/post";
import PostZone from "@/components/PostZone/PostZone.vue";
import Menu from "@/components/Menu/Menu.vue";
import MenuBar from "@/components/MenuBar/MenuBar.vue";
import {Comment} from "@/scripts/type/comment";
import {Topic} from "@/scripts/type/topic";
import SwitchBtn from "@/components/btn/SwitchZone.vue";
import FixedBtnZone from "@/components/btn/FixedBtnZone.vue";
import {post_data} from "@/scripts/data/post"
import {menu_posts} from "@/scripts/data/menu"
import {comments} from "@/scripts/data/comment"

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

/* 滑到底部查看壁纸 */
/*
onMounted(() => {
  const handler = (entries: IntersectionObserverEntry[]) => {
    entries.forEach(entry => {
      if (entry.intersectionRatio > 0.9) {
        commonOpacityStyle.value.opacity = 0
        commonOpacityStyle.value["pointer-events"] = 'none'
        pageFootOpacityStyle.value.opacity = 1
        pageFootOpacityStyle.value["pointer-events"] = 'unset'
      } else if (entry.intersectionRatio < 0.1) {
        commonOpacityStyle.value.opacity = 1
        commonOpacityStyle.value["pointer-events"] = 'unset'
        pageFootOpacityStyle.value.opacity = 0
        pageFootOpacityStyle.value["pointer-events"] = 'none'
      }
    })
  }

  let target =
      document.querySelector('#page-foot')
  if (target)
    new IntersectionObserver(handler, {
      root: null,
      rootMargin: '0px',
      threshold: [0, 1]
    }).observe(target)
})*/
</script>

<style lang="stylus" scoped>

.main
  background url("@/assets/pc.jpg")
  background-size cover
  background-position center
  background-attachment fixed

.content
  margin auto
  max-width 1160px

.router-view-enter-from
.router-view-leave-to
  opacity 0

.router-view-enter-active
.router-view-leave-active
  transition all 0.2s ease

/* 屏幕宽度 [ 1001  + ) */
@media (min-width 1001px)
  .content
    padding-top 8px
    width 99%

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
    width 76%
    max-width 1100px

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px)
  .right-part
    width 100%

/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px)
  .left-part
    width 23%
    min-width 230px
    max-width 270px
    position fixed

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px)
  .left-part
    display none

</style>
