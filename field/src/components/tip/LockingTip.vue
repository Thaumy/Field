<template>

  <div class="LockTip bE-white">
    <div class="con">此文章的评论系统已上锁。</div>
  </div>
</template>

<script>
import '@/styles/tip/common.css'

export default {
  name: "LockTip"
}
</script>

<style scoped>

.LockTip {
  background: rgb(255, 102, 0);
  padding-top: 3px;
  padding-bottom: 3px;
}

.LockTip::after {
  content: "\e3024";
}
</style>