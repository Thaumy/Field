<template>
  <div>

    <v-chip
        size="x-small"
        class="topic-chip"
    >
      <v-icon icon="mdi-pound" size="0.8rem"/>
      {{ topic }}
    </v-chip>

  </div>
</template>

<script lang="ts" setup>

import {defineProps} from "vue"

const props = defineProps({
  topic: String
})

</script>

<style lang="stylus" scoped>

@css {
  .topic-chip {
    color: rgb(var(--v-theme-on-surface), 0.9);
  }
}

</style>