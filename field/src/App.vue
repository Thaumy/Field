<template>
  <v-app class="main">
    <v-main>

      <NaviLine :pages="pages" :style="commonOpacityStyle"/>

      <div class="content">
        <NaviColumn :pages="pages" :style="commonOpacityStyle"/>

        <PostColumn :style="commonOpacityStyle"/>
      </div>
      <!--
      <div id="left_panel" :style="commonOpacityStyle">
        <SiderList/>
        <div class="Shadow" onclick="ListToggle()"></div>
      </div>-->

      <GoUpBtn :style="commonOpacityStyle"/>

    </v-main>
    <PageFoot
        id="page-foot"
        body='基于pilipala构建 - Field Theme Designed By Thaumy<br>
                      Thaumy的博客©2016-2023保留所有权利<br>
                      <a href="http://beian.miit.gov.cn/"
                         target="_blank"
                         style="color: rgba(255,255,255,0.6);
                          font-size: 0.7rem;
                          text-decoration: none;">
                        鲁ICP备2021005067</a>'
        style="margin: 30px"
        :style="pageFootOpacityStyle"/>
  </v-app>
</template>

<script lang="ts">
import {defineComponent} from 'vue'
import {notNullThen, PageSet} from "./scripts/common";

import NaviColumn from "@/components/NaviColumn/NaviColumn.vue";
import PostColumn from '@/components/PostColumn/PostColumn.vue'
import NaviLine from "@/components/NaviLine/NaviLine.vue";
import GoUpBtn from "@/components/btn/GoUpBtn.vue";
import PageFoot from "@/components/common/PageFoot.vue";

export default defineComponent({
  name: 'App',

  components: {
    PageFoot,
    GoUpBtn,
    NaviLine,
    NaviColumn,
    PostColumn,
  },
  data() {
    return {
      commonOpacityStyle: {
        opacity: 1,
        'pointer-events': 'unset',
        transition: 'all 0.2s ease'
      },
      pageFootOpacityStyle: {
        opacity: 1,
        'pointer-events': 'none',
        transition: 'all 0.2s ease'
      },
      pages: new PageSet([
        {id: 12345, title: '首页'},
        {id: 12346, title: '摸摸鱼'},
        {id: 12347, title: '追番'},
        {id: 12348, title: '看书'},
        {id: 12349, title: '写代码'},
        {id: 12350, title: '睡大觉'}]),
    }
  },
  mounted() {

    /* 滑到底部查看壁纸 */
    let target =
        document.querySelector('#page-foot')

    const handler = (entries: IntersectionObserverEntry[]) => {
      entries.forEach(entry => {
        if (entry.intersectionRatio > 0.9) {
          this.commonOpacityStyle.opacity = 0
          this.commonOpacityStyle["pointer-events"] = 'none'
          this.pageFootOpacityStyle.opacity = 1
          this.pageFootOpacityStyle["pointer-events"] = 'unset'
        } else if (entry.intersectionRatio < 0.1) {
          this.commonOpacityStyle.opacity = 1
          this.commonOpacityStyle["pointer-events"] = 'unset'
          this.pageFootOpacityStyle.opacity = 0
          this.pageFootOpacityStyle["pointer-events"] = 'none'
        }
      })
    }

    notNullThen(target,
        x => new IntersectionObserver(handler, {
          root: null,
          rootMargin: '0px',
          threshold: [0, 1]
        }).observe(x))
  }
})
</script>

<style scoped>
.main {
  background: url("@/assets/pc.jpg");
  background-size: cover;
  background-position: center;
  background-attachment: fixed;
}

.content {
  margin: auto;
  max-width: 1160px;
}
</style>

<style scoped>
/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
  .content {
    padding-top: 8px;
    width: 99%;
  }
}

/* 屏幕宽度 [ 601 , 1000 ] */
@media (min-width: 601px) and (max-width: 1000px) {
  .content {
    padding: 7px;
    padding-top: 57px;
  }
}

/* 屏幕宽度 ( - , 600 ] */
@media screen and (max-width: 600px) {
  .content {
    padding-top: 57px;
  }
}
</style>
