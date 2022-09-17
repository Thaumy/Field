<template>
  <div>

    <textarea
        class="f-textarea border-radius-all transition-standard"
        rows="3"
        v-model="modelValue"
        :placeholder="label"
        v-on:input="$emit('update:modelValue',$event.target.value)"
    />

  </div>
</template>

<script lang="ts" setup>

const props =
    defineProps<{
      label: string,
      modelValue: string
    }>()

defineEmits(['update:modelValue'])

</script>

<style lang="stylus" scoped>

.v-theme--fieldDark .f-textarea
  color #c8c8c8
  background-color #141414

.v-theme--fieldLight .f-textarea
  color #000000
  background-color #d2d2d2

.f-textarea
  width inherit
  min-height inherit
  max-height inherit

  font-size inherit
  text-align left

  padding 4px
  padding-left 6px
  padding-right 6px

  display block

@css {
  .f-textarea:focus {
    outline: none;
    box-shadow: inset 0 0 0 1px rgb(var(--v-theme-primary), var(--v-high-emphasis-opacity));
  }
}

</style>