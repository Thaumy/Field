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
    >
      <div class="snackbar-text">
        计划中的项目 / 此文章仍需迭代
      </div>
    </v-snackbar>

  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";

export default defineComponent({
  name: "ScheduleTip",
  data() {
    return {
      snackbarVisibility: false,
    }
  },
  methods: {
    toggleSnackBar() {
      this.snackbarVisibility = !this.snackbarVisibility
    },
  }
})
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