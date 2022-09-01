<template>
  <div>

    <f-card
        :style="{margin:'auto'}"
    >
      <div class="switch-zone">
        <v-chip
            class="prev-btn cursor-pointer"
            variant="text"
            v-if="prev"
        >
          <v-icon icon="mdi-chevron-left"/>
          {{ prev }}
        </v-chip>

        <v-chip
            class="next-btn cursor-pointer"
            variant="text"
            v-if="next"
        >
          {{ next }}
          <v-icon icon="mdi-chevron-right"/>
        </v-chip>
      </div>
    </f-card>

  </div>
</template>

<script lang="ts" setup>
import FCard from "@/components/field/f-card.vue";
import {defineProps} from "vue";

defineProps({
  prev: {type: String, default: null},
  next: {type: String, default: null},
})
</script>

<style lang="stylus" scoped>
.switch-zone
  display flex
  justify-content end
  flex-flow wrap

.prev-btn
  margin-right auto

.next-btn
  margin-left 1rem

.prev-btn
.next-btn
  color rgba(1 153 255 1)

</style>