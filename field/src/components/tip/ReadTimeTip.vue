<template>
  <div>

    <div
        class="read-time-tip border-shadow"
        v-if="needMinute>1"
    >
      <div class="text">约 {{ wordCount }} 字 / 阅读需要 {{ needMinute }} 分钟</div>
      <div class="icon">
        <v-icon icon="mdi-timer-sand" size="18px"/>
      </div>
    </div>

  </div>
</template>

<script setup lang="ts">
import {defineProps} from "vue";
import '@/styles/tip/common.css'

const props = defineProps({
  wordCount: Number,
  needMinute: Number
})
</script>

<style scoped>

.read-time-tip {
  margin: auto;
  display: flex;
  justify-content: space-between;

  background: rgb(0 143 11 / 20%);
  /*day mode
  background: rgb(52, 165, 61);*/

  padding: 3px;

  color: white;
  font-size: 15px;

  border-radius: 3px;
}

.text {
  margin-left: 1%;
}

.icon {
  align-items: center;
}

</style>