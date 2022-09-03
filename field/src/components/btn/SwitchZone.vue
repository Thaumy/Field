<template>
  <div>

<<<<<<< Updated upstream
    <f-card
        :style="{margin:'auto'}"
    >
      <div class="switch-zone">
        <v-chip
            class="prev-btn cursor-pointer"
            variant="text"
            v-if="prev"
=======
    <div class="holder border-radius-all">
      <div class="prev-chip cursor-pointer">
        <v-chip
            prepend-icon="mdi-chevron-left"
            color="primary"
            variant="text"
>>>>>>> Stashed changes
        >
          <v-icon icon="mdi-chevron-left"/>
          {{ prev }}
        </v-chip>
<<<<<<< Updated upstream

        <v-chip
            class="next-btn cursor-pointer"
            variant="text"
            v-if="next"
        >
          {{ next }}
          <v-icon icon="mdi-chevron-right"/>
=======
      </div>

      <div class="next-chip cursor-pointer">
        <v-chip
            append-icon="mdi-chevron-right"
            color="primary"
            variant="text"
        >
          {{ next }}
>>>>>>> Stashed changes
        </v-chip>
      </div>
    </f-card>

  </div>
</template>

<script lang="ts" setup>
import FCard from "@/components/field/f-card.vue";
import {defineProps} from "vue";
import FCard from "@/components/field/f-card.vue";

defineProps({
  prev: {type: String, default: null},
  next: {type: String, default: null},
})
</script>

<style lang="stylus" scoped>
<<<<<<< Updated upstream
.switch-zone
=======
.holder
  backdrop-filter blur(20px)
>>>>>>> Stashed changes
  display flex
  justify-content end
  flex-flow wrap

.prev-chip
  margin-right auto

<<<<<<< Updated upstream
.next-btn
  margin-left 1rem

.prev-btn
.next-btn
  color rgba(1 153 255 1)

=======
@css {
  .holder {
    background-color: rgba(var(--v-theme-background), 0.7)
  }
}
>>>>>>> Stashed changes
</style>