<template>

  <div class="LockTip bE-white">
    <div class="con">此文章的评论系统已上锁。</div>
  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";
import '@/styles/tip/common.css'

export default defineComponent({
  name: "LockTip"
})
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