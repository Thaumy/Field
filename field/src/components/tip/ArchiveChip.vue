<template>
  <div>

    <v-chip
        class="archive-chip"
        color="orange"
        size="small"
        @click="toggleSnackbar()"
    >
      <v-icon icon="mdi-archive"/>
    </v-chip>

    <v-snackbar
        class="snackbar"
        v-model="snackbarVisibility"
        :timeout="2000"
        color="orange"
        location="top right"
        @click="toggleSnackbar()"
    >
      <div class="snackbar-text">
        当前文章已归档 / 不受维护的内容
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
</script>

<style scoped>
.archive-chip {
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