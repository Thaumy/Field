<template>

  <div class="ArchivTip border-shadow">
    <div class="con">此文章已归档：不受维护但仍具参考价值的内容。</div>
  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";
import '@/styles/tip/common.css'

export default defineComponent({
  name: "ArchiveTip"
})
</script>

<style scoped>

.ArchivTip {
  background: rgb(255, 165, 0);
  padding-top: 3px;
  padding-bottom: 3px;
}

.ArchivTip::after {
  content: "\e3016";
}
</style>