<template>
  <div>

    <div
        class="f-divider"
        :style=
            "{'margin-left': ml+'px',
             'margin-right': mr+'px'}"
    />

  </div>
</template>

<script lang="ts" setup>

withDefaults(
    defineProps<{
      ml: number,
      mr: number
    }>(), {
      ml: 8,
      mr: 8
    })

</script>

<style lang="stylus" scoped>

@css {
  .f-divider {
    border-top: 1px solid rgb(var(--v-theme-on-surface), 0.1);
  }
}

</style>