<template>
  <div>

    <div
        class="menu-bar border-shadow"
        :style="{'top':`${topPosition}px`}"
        v-show="visibility"
    >
      <div class="cursor-pointer flex" @click="">
        <img class="avatar border-shadow" src="@/assets/pp512.png" alt="avatar"/>
        <div class=" name">THAUMY的小站</div>
      </div>

      <transition name="open-drawer-btn">
        <v-icon
            class="open-drawer-btn"
            icon="mdi-menu"
            v-show="!drawerVisibility"
            @click="openDrawer()"
        />
      </transition>
    </div>

    <Drawer :visibility="drawerVisibility" :tabs="tabs"/>
    <Shadow :visibility="drawerVisibility" @click="closeDrawer()"/>

  </div>
</template>

<script lang="ts" setup>
import {onMounted, ref, PropType} from 'vue'
import {makeDebounce} from "@/scripts/util/debounce";
import Drawer from "./Drawer.vue";
import {Post} from "@/scripts/type/post";
import {Tab} from "@/components/field/type";
import Shadow from "@/components/MenuBar/Shadow.vue";

const props = defineProps({
  posts: Object as PropType<Post[]>
})

const tabs = <Tab[]><unknown[]>props.posts

const visibility = ref(true)
const drawerVisibility = ref(false)
const topPosition = ref(0)

function openDrawer() {
  drawerVisibility.value = true
  document.getElementsByTagName('html')[0].style.overflowY = 'hidden'
  visibility.value = true
}

function closeDrawer() {
  drawerVisibility.value = false
  document.getElementsByTagName('html')[0].style.overflowY = 'scroll'
  visibility.value = true
}

onMounted(() => {
  //TODO 此实现有缺陷，当快速在阈值附近resize时，不能正确收起drawer
  //TODO 此问题已被解决，等待测试
  window.addEventListener('resize', makeDebounce(() => {
    if (window.innerWidth > 1000) {//触发宽度外，收起SiderList和shadow
      drawerVisibility.value = false
      document.getElementsByTagName('html')[0].style.overflowY = 'scroll'
    }
  }, 200))

  {
    let prev = 0
    let next = 0
    window.addEventListener('scroll', makeDebounce(() => {
      next = window.scrollY
      if (next < 50) {
        topPosition.value = -next
      } else {
        topPosition.value = next < prev ? 0 : -50//向下滚动收起，向上滚动展开
      }
      prev = next
    }, 100))
  }
})
</script>

<style lang="stylus" scoped>

.menu-bar
  display flex
  justify-content space-between

  height 50px
  width 100%
  z-index 20
  position fixed

  background rgba(0 0 0 0.8)
  backdrop-filter saturate(180%) blur(20px)
  transition all 0.1s ease

.name
  font-size 20px
  font-weight 400
  letter-spacing 4px
  line-height 50px
  color rgba(250 250 250 1)

.avatar
  width 42px
  height 41px
  margin 4px 10px 4px 10px
  border-radius 50px

.open-drawer-btn
  margin-right 12px
  align-self center

.open-drawer-btn-enter-from
.open-drawer-btn-leave-to
  opacity 0

/* 屏幕宽度 [ 1001  + ) */
@media (min-width 1001px)
  .menu-bar
    display none

</style>
