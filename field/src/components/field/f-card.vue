<template>
  <div>

    <div
        class="f-card border-line"
        :style="{'border-radius': radius+'px'}"
    >
      <slot/>
    </div>

  </div>
</template>

<script lang="ts" setup>
defineProps({
  radius: {
    type: Number,
    default: 4
  }
})
</script>

<style lang="stylus" scoped>
.f-card
  overflow hidden

@css {
  .f-card {
    background: rgb(var(--v-theme-surface));
  }
}
</style>