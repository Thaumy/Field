<template>
  <div>

    <!--Banishment<br>
    PixivID:75993030<br>-->

    <div class="page-foot" v-html="body"></div>

  </div>
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
.page-foot {
  color: white;
  text-align: center;
  letter-spacing: 1px;
  line-height: 24px;
  font-weight: 400;
}
</style>