<template>
  <transition name="shadow" tag="div">

    <div class="shadow" v-show="visibility"/>

  </transition>
</template>

<script lang="ts" setup>

withDefaults(
    defineProps<{
      visibility: boolean,
      type: boolean
    }>(), {
      visibility: false
    })

</script>

<style lang="stylus" scoped>

.shadow
  width calc(100% - 240px) /*多出来的4像素用来弥补可能的渲染误差导致的空隙*/
  height 100%
  z-index 5

  position fixed
  padding-top 50px
  left 242px

  background-color rgba(0 0 0 0.8)
  backdrop-filter saturate(10%)

.shadow-enter-from
.shadow-leave-to
  width 100%
  left 0
  opacity 0

.shadow-enter-active
.shadow-leave-active
  transition all 0.2s ease

/* 屏幕宽度 [ 1001  + ) */
@media (min-width 1001px)
  .shadow
    display none

</style>