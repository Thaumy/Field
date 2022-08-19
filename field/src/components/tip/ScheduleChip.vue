<template>
  <div>

    <v-chip
        class="schedule-chip"
        color="blue"
        size="small"
        @click="toggleSnackBar()"
    >
      <v-icon icon="mdi-calendar-check"></v-icon>
    </v-chip>

    <v-snackbar
        class="snackbar"
        v-model="snackbarVisibility"
        :timeout="2000"
        color="blue"
        location="top right"
        @click="toggleSnackBar()"
    >
      <div class="snackbar-text">
        计划中的项目 / 此文章仍需迭代
      </div>
    </v-snackbar>

  </div>
</template>

<script setup lang="ts">
import {ref} from "vue";

const snackbarVisibility = ref(false)

function toggleSnackBar() {
  snackbarVisibility.value = !snackbarVisibility.value
}
</script>

<style scoped>
.schedule-chip {
  margin-left: 2px;
  margin-right: 2px;
}

.snackbar {
  margin-top: 50px;
}

.snackbar-text {
  width: fit-content;
  margin: auto;
  color: white;
}
</style>