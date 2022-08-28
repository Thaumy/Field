<template>
  <div>

    <f-card class="menu">

      <Avatar avatarUrl="src/assets/pp512.png"/>

      <Info
          title="THAUMY的小站"
          :typing="[
            '你好！~~^400',
            '这里是THAUMY的博客！^300',
            '又一个码农的家',
            '又一个码农的家.',
            '又一个码农的家..',
            '又一个码农的家...']"
      />

      <f-tabs vertical double-bar :tabs="tabs"/>

      <About info="Thaumy's Blog©2016-2023<br>About Site" v-ripple/>

    </f-card>

  </div>
</template>

<script lang="ts" setup>
import {defineProps, PropType, ref} from "vue";
import About from "./About.vue";
import Info from "./Info.vue";
import Avatar from "./Avatar.vue";
import {Post} from "@/scripts/type/post";
import FCard from "@/components/field/f-card.vue";
import FTabs from "@/components/field/f-tabs.vue";
import {Tab} from "@/components/field/type";

const props = defineProps({
  posts: Object as PropType<Post[]>
})
const tabs = <Tab[]><unknown[]>props.posts
//TODO show post by tab
</script>

<style lang="stylus" scoped>

.menu
  color rgba(230 230 230 1.00)

</style>