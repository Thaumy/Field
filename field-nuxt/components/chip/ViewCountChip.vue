<template>
  <div>

    <v-chip
        color="grey"
        size="x-small"
        variant="text"
    >
      <v-icon icon="mdi-account-multiple"/>
      <div class="count" v-text="count"/>
    </v-chip>

  </div>
</template>

<script lang="ts" setup>

const props =
    defineProps<{
      count: number
    }>()

</script>

<style lang="stylus" scoped>

.count
  margin-left 4px

</style>
