<template>
  <div>

    <div class="holder border-radius-all">
      <div class="prev-chip cursor-pointer">
        <v-chip
            prepend-icon="mdi-chevron-left"
            color="primary"
            variant="text"
        >
          {{ prev }}
        </v-chip>
      </div>

      <div class="next-chip cursor-pointer">
        <v-chip
            append-icon="mdi-chevron-right"
            color="primary"
            variant="text"
        >
          {{ next }}
        </v-chip>
      </div>
    </div>

  </div>
</template>

<script lang="ts" setup>
import {defineProps} from "vue";

defineProps({
  prev: {type: String, default: null},
  next: {type: String, default: null},
})
</script>

<style lang="stylus" scoped>
.holder
  backdrop-filter blur(20px)
  display flex
  justify-content end
  flex-flow wrap

.prev-chip
  margin-right auto

@css {
  .holder {
    background-color: rgba(var(--v-theme-background), 0.7)
  }
}
</style>