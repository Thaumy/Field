<template>
  <div>

    <div class="holder">
      <div
          class="prev-btn cursor-pointer"
      >
        {{ prev }}
      </div>

      <div
          class="next-btn cursor-pointer"
      >
        {{ next }}
      </div>
    </div>

  </div>
</template>

<script lang="ts" setup>
import {defineProps} from "vue";

defineProps({
  prev: String,
  next: String
})
</script>

<style lang="stylus" scoped>
.holder
  display flex
  justify-content space-between

.next-btn
.prev-btn
  color rgba(1 153 255 1)
  font-size 17px
  line-height 17px

  margin 3px
  padding 3px

  overflow hidden
  white-space nowrap
  text-overflow ellipsis

.prev-btn
  padding-right 6px
  padding-left 0px

.next-btn
  padding-left 6px
  padding-right 0px
</style>