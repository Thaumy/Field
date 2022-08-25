<template>
  <div>

    <div
        class="read-time-bar border-shadow"
        v-if="minutes>1"
    >
      <div style="margin-left:1%">
        约 {{ words }} 字 / 阅读成本 {{ minutes }} 分钟
      </div>

      <v-icon
          icon="mdi-timer-sand"
          size="18px"
          style="align-self: center"
      />
    </div>

  </div>
</template>

<script setup lang="ts">
import {defineProps, ref} from "vue";

const props = defineProps({
  targetText: String,
})

const words = ref(6600)
const minutes = ref(12)

//TODO auto calculus...
</script>

<style lang="stylus" scoped>

.read-time-bar
  margin auto
  display flex
  justify-content space-between

  background rgba(0 143 11 20%)

  //day mode
  //background rgb(52 165 61)

  padding 3px

  font-size 15px
  border-radius 3px
</style>