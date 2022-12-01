<template>
  <div>

    <div class="fixed-btn-zone">
      <go-up-btn class="mb-1"/>
    </div>

  </div>
</template>

<script lang="ts" setup>

import GoUpBtn from "@/components/btn/GoUpBtn.vue"

</script>

<style lang="stylus" scoped>

.fixed-btn-zone
  display flex
  flex-direction column
  position fixed
  z-index 1
  bottom 10%

/* 屏幕宽度 [ 1491  + ) */
@media (min-width 1491px)
  .fixed-btn-zone
    right 6%

/* 屏幕宽度 [ 1001  1490 ] */
@media (min-width 1001px) and (max-width 1490px)
  .fixed-btn-zone
    right 2%

/* 屏幕宽度 ( -  1000 ] */
@media (max-width 1000px)
  .fixed-btn-zone
    left 2%

</style>