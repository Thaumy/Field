<template>
  <div>

    <v-chip
        color="grey"
        size="x-small"
        variant="text"
    >
      <v-icon icon="mdi-message-reply-outline" size="0.8rem"/>
      <div class="count" v-text="count"/>
    </v-chip>

  </div>
</template>

<script lang="ts" setup>

import {defineProps} from "vue"

const props = defineProps<{
  count: number
}>()

</script>

<style lang="stylus" scoped>

.count
  margin-left 4px

</style>