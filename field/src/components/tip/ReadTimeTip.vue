<template>
  <div>

    <div class="read-time-tip border-shadow">
      <div class="text">约 6600 字 / 阅读需要 5 分钟</div>
      <v-icon icon="mdi-timer-sand"/>
    </div>

  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";
import '@/styles/tip/common.css'

export default defineComponent({
  name: "ReadTimeTip"
})
</script>

<style scoped>

.read-time-tip {
  margin: auto;
  width: 98%;
  display: flex;
  justify-content: space-between;

  background: rgb(52, 165, 61);
  padding: 3px;

  color: white;
  font-size: 15px;

  border-radius: 3px;
}

.text {
  margin-left: 1%;
}

</style>