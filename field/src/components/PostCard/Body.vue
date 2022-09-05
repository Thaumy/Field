<template>
  <div>

    <div class="body transition-standard">

      <f-text-render
          style="padding: 6px"
          :text="body"
      />

      <div class="bottom-slot">
        <slot name="bottom-slot"/>
      </div>

    </div>

  </div>
</template>

<script setup lang="ts">
import {onMounted, defineProps, PropType, toRefs} from "vue"
import FTextRender from "@/components/field/f-text-render.vue";

const props = defineProps({
  body: String,
  createTime: Object as PropType<Date>,
  modifyTime: Object as PropType<Date>
})

</script>

<style lang="stylus" scoped>

.body
  padding 6px

@css {
  .body {
    background: rgb(var(--v-theme-surface));
  }
}

img
  border-top-left-radius 3px
  border-top-right-radius 3px
  margin-bottom -5px

.bottom-slot
  display flex
  justify-content space-between

</style>