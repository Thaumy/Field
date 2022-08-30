<template>
  <div>

    <v-chip color="grey" size="x-small">
      <v-icon icon="mdi-message-reply-outline" size="12"/>
      <div class="count">{{ commentCount }}</div>
    </v-chip>

  </div>
</template>

<script lang="ts" setup>
import {defineProps} from "vue";

const props = defineProps({
  commentCount: Number
})

</script>

<style lang="stylus" scoped>

.count
  margin-left 4px

//color="grey"
/*
@css {
  .count {
    color: rgba(var(--v-theme-on-surface), var(--v-activated-opacity));
  }
}*/
</style>