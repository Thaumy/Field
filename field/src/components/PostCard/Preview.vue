<template>
  <div>

    <div
        class="preview"
    >
      <div class="title-flex" v-if="title">
        <div
            class="title cursor-pointer"
            @click="$emit('titleClick')"
        >
          {{ title }}
        </div>

        <div class="title-right-slot">
          <slot name="title-right-slot"/>
        </div>
      </div>

      <div class="summary-flex" v-if="title&&summary">
        <div
            class="summary cursor-pointer"
            @click="$emit('summaryClick')"
        >
          {{ summary }}
        </div>

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
import {Comment} from "@/scripts/type/comment";

let props = defineProps({
  title: String,
  summary: String,
  blurBg: Boolean
})

</script>

<style lang="stylus" scoped>

.preview
  padding 7px
  display grid
  grid-template-columns 100%
  grid-template-rows auto auto auto

.title-flex
  display flex
  padding 2px
  padding-left 6px
  justify-content end

.summary-flex
  display flex
  flex-wrap wrap
  justify-content end

.summary
  margin-right auto
  margin-bottom 10px
  padding-left 18px
  font-size 0.9rem
  word-break break-all

.title
  margin-right auto
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