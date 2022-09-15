<template>
  <div>

    <div
        class="preview"
    >
      <div class="title-flex" v-if="title">
        <div
            class="title"
            v-text="title"
        />

        <div class="title-right-slot">
          <slot name="title-right-slot"/>
        </div>
      </div>

      <div class="summary-flex" v-if="title&&summary">
        <div
            class="summary"
            :class="{'generated':isGeneratedSummary}"
            v-text="summary"
        />

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

let props = defineProps<{
  title: string,
  summary: string,
  isGeneratedSummary: boolean,
}>()

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
  overflow hidden

.summary
  margin-right auto
  margin-bottom 10px
  padding-left 18px
  padding-right 18px
  font-size 0.9rem
  word-break break-all
  white-space nowrap
  overflow hidden
  text-overflow ellipsis

.title
  margin-right auto
  font-size 1.4rem
  word-break break-all

@css {
  .title {
    color: rgb(var(--v-theme-on-surface));
  }
  .summary {
    color: rgba(var(--v-theme-on-surface), 0.8);
  }
  .summary[class~=generated] {
    color: rgba(var(--v-theme-on-surface), 0.4);
  }
}

.title-right-slot
  display flex
  align-items center

.summary-right-slot
  display flex

</style>