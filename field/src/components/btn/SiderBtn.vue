<template>

</template>

<script lang="ts">
import {defineComponent} from "vue";
export default defineComponent({
  name: "SiderBtn"
})
</script>

<style scoped>

.SiderBtn {
  font-size: 26px;
  line-height: 50px;

  color: #FFFFFF;
}

.SiderBtn::before {
  font-family: 'field-icon';

  margin: 12px;
  content: "\e3018";
}
</style>