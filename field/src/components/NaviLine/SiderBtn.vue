<template>
  <div>

    <div class="sider-btn float-right"></div>

  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";

export default defineComponent({
  name: "SiderBtn",
})
</script>

<style scoped>

.sider-btn {
  font-size: 26px;
  line-height: 50px;

  color: #FFFFFF;
}

.sider-btn::before {
  font-family: 'field-icon';

  margin: 12px;
  content: "\e3018";
}
</style>