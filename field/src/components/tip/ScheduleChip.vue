<template>
  <div>

    <v-chip
        class="schedule-chip"
        color="blue"
        size="small"
        @click="toggleSnackbar()"
    >
      <v-icon icon="mdi-calendar-check"></v-icon>
    </v-chip>

    <v-snackbar
        class="snackbar"
        v-model="snackbarVisibility"
        :timeout="3000"

        color="blue"
        location="top right"
        @click="toggleSnackbar()"
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

function toggleSnackbar() {
  snackbarVisibility.value = !snackbarVisibility.value
}

/*
const second = ref(3)
const percentage = ref(100)

let percentageAnimation = 0
let secondAnimation = 0

function activeAnimation() {
  secondAnimation =
      setInterval(() => {
        second.value--
      }, 1000)
  percentageAnimation =
      setInterval(() => {
        percentage.value -= 6.6
      }, 200)
}

function resetAnimation() {
  clearInterval(secondAnimation)
  clearInterval(percentageAnimation)
  second.value = 3
  percentage.value = 100
}

function toggleSnackBar() {
  if (!snackbarVisibility.value) {
    snackbarVisibility.value = true
    activeAnimation()
    setTimeout(() => resetAnimation(), 3000)
  } else {
    snackbarVisibility.value = false
    resetAnimation()
  }
}*/
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