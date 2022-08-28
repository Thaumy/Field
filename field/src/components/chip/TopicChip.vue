<template>
  <div>

    <v-chip
        size="x-small"
        color="on-surface"
    >
      <v-icon icon="mdi-pound" size="0.8rem"/>
      {{ topic }}
    </v-chip>

  </div>
</template>

<script setup lang="ts">
import {defineProps} from "vue";

const props = defineProps({
  topic: String
})

</script>

<style scoped>

</style>