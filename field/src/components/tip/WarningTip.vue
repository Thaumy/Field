<template>

  <div class="WarningTip bE-white">
    <div class="con">CommentLake提交系统尚处于开发状态，这意味着评论功能尚不完全可用。</div>
  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";
import '../../styles/tip/common.css'

export default defineComponent({
  name: "WarningTip"
})
</script>

<style scoped>

.WarningTip {
  background: rgb(255, 165, 0);
  padding-top: 3px;
  padding-bottom: 3px;
}

.WarningTip::after {
  content: "\e3023";
}
</style>