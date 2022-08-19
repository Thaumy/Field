<template>
  <div><!--防止外部样式干涉-->

    <div :style="{'top':`${lineTopPosition}px`}"
         class="NavLine float-left margin-bottom border-shadow"
         v-show="lineVisibility"
    >

      <div
          class="cursor-pointer border-radius-all"
          onclick="up()"
      >
        <img class="Avatar border-shadow" src="@/assets/pp512.png">
        <div class=" Name">THAUMY的小站</div>
      </div>

      <transition name="sider-btn">
        <SiderBtn @click="showList()" v-show="!listVisibility"/>
      </transition>
    </div>

    <transition name="sider-list">
      <SiderList class="sider-list" :pages="pages" v-show="listVisibility"/>
    </transition>

    <transition name="sider-list-shadow">
      <div class="shadow" v-show="listVisibility" @click="hideList()"></div>
    </transition>

  </div>
</template>

<script lang="ts">
import {PageSet} from "../../scripts/common";
import {makeDebounce} from "../../scripts/debounce";
import {defineComponent} from 'vue'

import SiderBtn from "./SiderBtn.vue";
import SiderList from "./SiderList.vue";

export default defineComponent({
  name: "NavLine",
  components: {SiderBtn, SiderList},
  props: {pages: PageSet},
  data() {
    return {
      lineVisibility: true,
      listVisibility: false,
      lineTopPosition: 0,
    }
  },
  methods: {
    showList() {
      this.listVisibility = true
      document.getElementsByTagName('html')[0].style.overflowY = 'hidden'
      this.lineVisibility = true
    },
    hideList() {
      this.listVisibility = false
      document.getElementsByTagName('html')[0].style.overflowY = 'scroll'
      this.lineVisibility = true
    }
  },
  mounted() {
    window.addEventListener('resize', makeDebounce(() => {
      if (window.innerWidth > 1000) {//触发宽度外，收起SiderList和shadow
        this.listVisibility = false
        document.getElementsByTagName('html')[0].style.overflowY = 'scroll'
      }
    }, 100))

    {
      let prev = 0
      let next = 0
      window.addEventListener('scroll', makeDebounce(() => {
        next = window.scrollY
        if (next < 50) {
          this.lineTopPosition = -next
        } else {
          this.lineTopPosition = next < prev ? 0 : -50//向下滚动收起，向上滚动展开
        }
        prev = next
      }, 100))
    }
  }
})
</script>

<style scoped>
.NavLine {
  height: 50px;
  width: 100%;
  z-index: 20;
  position: fixed;
  overflow: hidden;

  background: rgba(0, 0, 0, 0.8);
  backdrop-filter: saturate(180%) blur(20px);

  transition: all 0.1s ease;
}

.Name {
  float: left;

  font-size: 20px;
  font-weight: 400;
  letter-spacing: 4px;
  line-height: 50px;
  color: rgba(250, 250, 250, 1);
}

.Avatar {
  float: left;

  width: 42px;
  height: 41px;
  margin: 4px 10px 4px 10px;

  border-radius: 50px;
}

.sider-list {
  left: 0;
}

.shadow {
  width: calc(100% - 242px); /*多出来的4像素用来弥补可能的渲染误差导致的空隙*/
  height: 100%;
  z-index: 5;

  position: fixed;
  padding-top: 50px;
  left: 242px;

  background-color: rgba(0, 0, 0, 0.8);
  backdrop-filter: saturate(10%);
}
</style>

<style scoped>
/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
  .NavLine, .shadow {
    display: none;
  }
}

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px) {
}

.sider-list-enter-from,
.sider-list-leave-to {
  left: -246px;
}

.sider-list-enter-to,
.sider-list-leave-from {
  left: 0;
}

.sider-btn-enter-from,
.sider-btn-leave-to {
  opacity: 0;
}

.sider-list-shadow-enter-from,
.sider-list-shadow-leave-to {
  width: 100%;
  left: 0;
  opacity: 0;
}

.sider-btn-enter-active,
.sider-btn-leave-active,
.sider-list-enter-active,
.sider-list-leave-active,
.sider-list-shadow-enter-active,
.sider-list-shadow-leave-active {
  transition: all 0.2s ease;
}
</style>
