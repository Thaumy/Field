<template>
  <div>

    <v-chip
        size="small"
        class="topic-chip"
    >
      <v-icon class="mr-1" icon="mdi-pound" size="0.8rem"/>
      {{ topic }}
    </v-chip>

  </div>
</template>

<script lang="ts" setup>

const props =
    defineProps<{
      topic: string
    }>()

</script>

<style lang="stylus" scoped>

@css {
  .topic-chip {
    color: rgb(var(--v-theme-on-surface), 0.6);
  }
}

</style>