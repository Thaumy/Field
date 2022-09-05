<template>
  <div>

    <div
        class="f-tab"
        :class="{'cursor-pointer':!disabled}"
        v-ripple
        v-ripple.stop="!disabled"
        @click="disabled?()=>{}:$emit('click')"
    >
      <div
          :style="{color:disabled?'grey':'',
                 cursor:disabled?'default':'pointer'}"
          class="title"
          v-text="title"
      />
    </div>

  </div>
</template>

<script lang="ts" setup>

import {defineProps} from "vue";

const emits = defineEmits<{
  (e: 'click'): void
}>()

const props = withDefaults(
    defineProps<{
      title: string,
      disabled: boolean
    }>(), {
      disabled: false
    })

</script>

<style lang="stylus" scoped>

.f-tab
  display flex

  height 100%

  .title
    margin auto

@css {
  .f-tab .title {
    color: rgb(var(--v-theme-on-surface));
  }
}


</style>