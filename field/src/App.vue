<template>
  <v-app class="main">
    <v-main>

      <NaviBar :pages="pages" :style="commonOpacityStyle"/>

      <div class="content">
        <NaviColumn :pages="pages" :style="commonOpacityStyle"/>

        <PostColumn :style="commonOpacityStyle"/>
      </div>

      <GoUpBtn :style="commonOpacityStyle"/>

    </v-main>

    <PageFoot
        id="page-foot"
        body="基于pilipala构建 - Field Theme Designed By Thaumy<br>
                      Thaumy'Blog 2016-2023<br>
                      <a href='http://beian.miit.gov.cn/'
                         target='_blank'
                         style='color: rgba(255,255,255,0.6);
                          font-size: 0.7rem;
                          text-decoration: none;'>
                        鲁ICP备2021005067</a>"
        style="margin: 20px;margin-top: 80px"
        :style="pageFootOpacityStyle"/>
  </v-app>
</template>

<script lang="ts" setup>
import {onMounted, ref} from 'vue'
import NaviColumn from "@/components/NaviColumn/NaviColumn.vue";
import PostColumn from '@/components/PostColumn/PostColumn.vue'
import NaviBar from "@/components/NaviLine/NaviBar.vue";
import GoUpBtn from "@/components/btn/GoUpBtn.vue";
import PageFoot from "@/components/common/PageFoot.vue";

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

const pages = ref([
  {id: 12345, title: '首页'},
  {id: 12346, title: '摸摸鱼'},
  {id: 12347, title: '追番'},
  {id: 12348, title: '看书'},
  {id: 12349, title: '写代码'},
  {id: 12350, title: '睡大觉'}])

/* 滑到底部查看壁纸 */
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
})
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
@media screen and (max-width 600px)
  .content
    padding-top 57px

</style>
