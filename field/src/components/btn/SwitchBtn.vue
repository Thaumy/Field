<template>
  <div>

    <div class="holder">
      <div class="prev-btn cursor-pointer">
        <v-btn
            prepend-icon="mdi-chevron-left"
            color="rgb(30,30,30)"
            flat=""
        >
          {{ prev }}
        </v-btn>
      </div>

      <div class="next-btn cursor-pointer">
        <v-btn
            append-icon="mdi-chevron-right"
            color="rgb(30,30,30)"
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
  justify-content center
  flex-flow wrap

.next-btn
.prev-btn
  color rgba(1 153 255 1)

  white-space nowrap
  text-overflow ellipsis

</style>