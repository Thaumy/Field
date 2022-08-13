<template>

  <div class="SchedulTip bSha">
    <div class="con">计划中的项目：此文章将会于近期更新。</div>
  </div>

</template>

<script>
import '@/styles/tip/common.css'

export default {
  name: "ScheduleTip"
}
</script>

<style scoped>

.SchedulTip {
  background: rgb(0, 120, 215);
  padding-top: 3px;
  padding-bottom: 3px;
}
.SchedulTip::after {
  content: "\e3017";
}
</style>