<template>
  <div>

    <div class="tab cursor-pointer border-radius-all">
      <div class="title">{{ title }}</div>
    </div>

  </div>
</template>

<script lang="ts" setup>
import {defineProps} from "vue";

defineProps({
  title: String
})
</script>

<style lang="stylus" scoped>
.tab
  display flex
  width 94%

  height 6vh
  max-height 44px
  min-height 28px

  margin auto
  margin-top 2px
  margin-bottom 2px

  font-size 17px
  letter-spacing 1px
  color rgba(230 230 230 1.00)

.title
  margin-right auto
  align-self center
  margin-left auto
</style>
