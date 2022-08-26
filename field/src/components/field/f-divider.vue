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
import {defineProps} from "vue";

defineProps({
  ml: {
    type: Number,
    default: 8
  },
  mr: {
    type: Number,
    default: 8
  },
})
</script>

<style lang="stylus" scoped>
.f-divider
  border-top 1px solid rgb(50 50 50)
</style>