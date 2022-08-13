<template>

  <div class="ReadTimeTip bSha">
    <div class="con">约 6600字 阅读需要 5分钟</div>
  </div>
</template>

<script>
import '@/styles/tip/common.css'

export default {
  name: "ReadTimeTip"
}
</script>

<style scoped>

.ReadTimeTip {
  background: rgb(52, 165, 61);
  padding-top: 3px;
  padding-bottom: 3px;
}

.ReadTimeTip::after {
  content: "\e3004";
}
</style>