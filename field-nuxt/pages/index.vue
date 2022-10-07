<template>
  <transition name="router-view">
    <NuxtPage keepalive/>
  </transition>
</template>

<script lang="ts" setup>

</script>

<style lang="stylus" scoped>

.router-view-leave-active
.router-view-enter-active
  transition all 0.2s ease

.router-view-enter-from
  height 0
  transform scale(0.9)

.router-view-leave-to
  height 0
  opacity 0

</style>