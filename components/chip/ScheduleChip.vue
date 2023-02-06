<template>
  <div>

    <v-chip
        class="schedule-chip"
        color="blue"
        size="small"
        @click.stop="showGlobalSnackbar('mdi-calendar','计划中的项目 / 此文章仍需迭代','blue')"
    >
      <v-icon icon="mdi-calendar"></v-icon>
    </v-chip>

  </div>
</template>

<script setup lang="ts">

import {inject} from "vue"

const showGlobalSnackbar = inject('showGlobalSnackbar')

</script>

<style lang="stylus" scoped>

.schedule-chip
  margin-left 2px
  margin-right 2px

</style>