<template>
  <div>

    <div class="holder">
      <div class="prev-btn cursor-pointer">
        <v-btn
            prepend-icon="mdi-chevron-left"
            color="surface"
            flat=""
        >
          {{ prev }}
        </v-btn>
      </div>

      <div class="next-btn cursor-pointer">
        <v-btn
            append-icon="mdi-chevron-right"
            color="surface"
            flat=""
        >
          {{ next }}
        </v-btn>
      </div>
    </div>

  </div>
</template>

<script lang="ts" setup>
import {defineProps} from "vue";

defineProps({
  prev: String,
  next: String
})
</script>

<style lang="stylus" scoped>
.holder
  display flex
  justify-content end
  flex-flow wrap

.prev-btn
  margin-right auto

.prev-btn
.next-btn
  color rgba(1 153 255 1)

</style>