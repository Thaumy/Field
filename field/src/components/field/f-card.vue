<template>
  <div>

    <div class="f-card border-line border-radius-all">
      <slot/>
    </div>

  </div>
</template>

<script lang="ts" setup>
</script>

<style lang="stylus" scoped>
.f-card
  background: var(--b30)
  overflow hidden
</style>