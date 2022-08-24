<template>
  <div>

    <div
        class="navi-bar border-shadow"
        :style="{'top':`${lineTopPosition}px`}"
        v-show="lineVisibility"
    >
      <div
          class="cursor-pointer flex"
          onclick="up()"
      >
        <img class="Avatar border-shadow" src="@/assets/pp512.png"/>
        <div class=" Name">THAUMY的小站</div>
      </div>

      <transition name="show-menu-btn">
        <v-icon
            class="show-menu-btn"
            icon="mdi-menu"
            v-show="!listVisibility"
            @click="showList()"
        />
      </transition>
    </div>

    <transition name="menu">
      <Menu class="menu" :pages="pages" v-show="listVisibility"/>
    </transition>

    <transition name="menu-shadow">
      <div class="menu-shadow" v-show="listVisibility" @click="hideList()"/>
    </transition>

  </div>
</template>

<script lang="ts" setup>
import {onMounted, ref, PropType} from 'vue'
import {makeDebounce} from "@/scripts/debounce";
import Menu from "./Menu.vue";
import {Page} from "@/scripts/common";

defineProps({pages: Object as PropType<Page[]>})
const lineVisibility = ref(true)
const listVisibility = ref(false)
const lineTopPosition = ref(0)

function showList() {
  listVisibility.value = true
  document.getElementsByTagName('html')[0].style.overflowY = 'hidden'
  lineVisibility.value = true
}

function hideList() {
  listVisibility.value = false
  document.getElementsByTagName('html')[0].style.overflowY = 'scroll'
  lineVisibility.value = true
}

onMounted(() => {
  window.addEventListener('resize', makeDebounce(() => {
    if (window.innerWidth > 1000) {//触发宽度外，收起SiderList和shadow
      listVisibility.value = false
      document.getElementsByTagName('html')[0].style.overflowY = 'scroll'
    }
  }, 100))

  {
    let prev = 0
    let next = 0
    window.addEventListener('scroll', makeDebounce(() => {
      next = window.scrollY
      if (next < 50) {
        lineTopPosition.value = -next
      } else {
        lineTopPosition.value = next < prev ? 0 : -50//向下滚动收起，向上滚动展开
      }
      prev = next
    }, 100))
  }
})
</script>

<style lang="stylus" scoped>
.navi-bar
  display flex
  justify-content space-between

  height 50px
  width 100%
  z-index 20
  position fixed

  background rgba(0 0 0 0.8)
  backdrop-filter saturate(180%) blur(20px)
  transition all 0.1s ease

.Name
  font-size 20px
  font-weight 400
  letter-spacing 4px
  line-height 50px
  color rgba(250 250 250 1)

.Avatar
  width 42px
  height 41px
  margin 4px 10px 4px 10px

  border-radius 50px

.show-menu-btn
  margin-right 12px
  align-self center

.menu
  left 0

.menu-shadow
  width calc(100% - 242px) /*多出来的4像素用来弥补可能的渲染误差导致的空隙*/
  height 100%
  z-index 5

  position fixed
  padding-top 50px
  left 242px

  background-color rgba(0 0 0 0.8)
  backdrop-filter saturate(10%)

.menu-enter-from
.menu-leave-to
  left -246px

.menu-enter-to
.menu-leave-from
  left 0

.show-menu-btn-enter-from
.show-menu-btn-leave-to
  opacity 0

.menu-shadow-enter-from
.menu-shadow-leave-to
  width 100%
  left 0
  opacity 0

.menu-enter-active
.menu-leave-active
.menu-enter-active
.menu-leave-active
.menu-shadow-enter-active
.menu-shadow-leave-active
  transition all 0.2s ease

/* 屏幕宽度 [ 1001  + ) */
@media (min-width 1001px)
  .navi-bar
  .menu-shadow
    display none
</style>
