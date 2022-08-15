<template>

  <!--Banishment<br>
  PixivID:75993030<br>-->

  <div v-html="body"></div>

</template>

<script lang="ts">
import {defineComponent} from "vue";

export default defineComponent({
  name: "PageFoot",
  props: {
    body: String
  }
})
</script>

<style scoped>

div {
  float: right;
  color: white;
  width: 100%;
  text-align: center;
  height: 100px;
  letter-spacing: 1px;
  line-height: 24px;
  font-weight: 400;
}

</style>