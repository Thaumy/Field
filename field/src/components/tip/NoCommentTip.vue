<template>

  <div class="CommentTip bE-white">
    <div class="con">评论尚无，快来吃个螃蟹！</div>
  </div>

</template>

<script lang="ts">
import {defineComponent} from "vue";
import '@/styles/tip/common.css'

export default defineComponent({
  name: "PlanningTip"
})
</script>

<style scoped>

.CommentTip {
  background: rgb(0, 153, 255);
  padding-top: 3px;
  padding-bottom: 3px;
}

.CommentTip::after {
  content: "\e3003";
}
</style>