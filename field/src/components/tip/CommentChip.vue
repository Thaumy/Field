<template>

  <v-chip color="grey" size="x-small">
    <v-icon icon="mdi-message-reply-outline" size="12"/>
    <div class="comment-count">{{ commentCount }}</div>
  </v-chip>

</template>

<script setup lang="ts">
import {defineProps} from "vue";

const props = defineProps({commentCount: Number})

</script>

<style scoped>
.comment-count {
  margin-left: 4px;
}
</style>