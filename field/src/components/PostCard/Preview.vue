<template>
  <div>

    <div
        class="preview"
    >
      <div class="title-flex" v-if="title">
        <div class="title">{{ title }}</div>

        <div class="title-right-slot">
          <slot name="title-right-slot"/>
        </div>
      </div>

      <div class="summary-flex" v-if="title&&summary">
        <div class="summary">{{ summary }}</div>

        <div class="summary-right-slot">
          <slot name="summary-right-slot"/>
        </div>
      </div>

      <slot name="bottom-slot"/>

    </div>

  </div>
</template>

<script setup lang="ts">
import {defineProps} from "vue";

let props = defineProps({
  title: String,
  summary: String,
  blurBg: Boolean
})

</script>

<style lang="stylus" scoped>

.preview
  padding 6px
  display grid
  grid-template-columns 100%
  grid-template-rows auto auto auto

.title-flex
  display flex
  padding 2px
  padding-left 6px
  justify-content space-between

.summary-flex
  display flex
  flex-wrap wrap
  justify-content end

.summary
  font-size 0.9rem
  margin-right auto
  margin-bottom 10px
  padding-left 18px
  word-break break-all

.title
  font-size 1.4rem
  word-break break-all

@css {
  .title {
    color: rgb(var(--v-theme-on-surface));
  }
}

.title-right-slot
  display flex
  align-items center

.summary-right-slot
  display flex

</style>