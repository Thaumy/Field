<template>
  <div>

    <div class="body">
      <div class="content markdown-body" v-html="body" v-if="body"/>

      <div class="bottom-slot">
        <slot name="bottom-slot"/>
      </div>
    </div>

  </div>
</template>

<script setup lang="ts">
import {createApp, defineProps, PropType, toRefs} from "vue";

const props = defineProps({
  body: String,
  createTime: Date as PropType<Date>,
  modifyTime: Date as PropType<Date>
})

</script>

<style>
@import "@/styles/dark/markdown-dark.css";
</style>

<style scoped>
.body {
  padding: 6px;
  background: rgba(30, 30, 30, 1.00);
}

.content {
  /* 颜色模式 */
  color: rgba(240, 240, 240, 1.00);
}

img {
  border-top-left-radius: 3px;
  border-top-right-radius: 3px;
  margin-bottom: -5px;
}

.content {
  padding: 6px;

  font-size: 15px;
  line-height: 22px;
  letter-spacing: 1px;
  word-break: break-word;
}

.bottom-slot {
  display: flex;
  justify-content: space-between;
}
</style>