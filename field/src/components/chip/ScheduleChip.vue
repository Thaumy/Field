<template>
  <div>

    <v-chip
        class="schedule-chip"
        color="blue"
        size="small"
        @click.stop="toggleSnackbar()"
    >
      <v-icon icon="mdi-calendar-check"></v-icon>
    </v-chip>

    <v-snackbar
        content-class="snackbar"
        v-model="snackbarVisibility"
        :timeout="2000"
        color="blue"
        location=""
        @click="toggleSnackbar()"
    >
      <div class="snackbar-text">
        计划中的项目 / 此文章仍需迭代
      </div>
    </v-snackbar>

  </div>
</template>

<script setup lang="ts">
import {ref} from "vue"

const snackbarVisibility = ref(false)

function toggleSnackbar() {
  snackbarVisibility.value = !snackbarVisibility.value
}

</script>

<style lang="stylus" scoped>

.schedule-chip
  margin-left 2px
  margin-right 2px

.snackbar-text
  width fit-content
  margin auto
  color white

</style>