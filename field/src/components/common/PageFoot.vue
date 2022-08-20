<template>
  <div>

    <!--Banishment<br>
    PixivID:75993030<br>-->

    <div class="page-foot" v-html="body"></div>

  </div>
</template>

<script setup lang="ts">
import {defineProps} from "vue";

const props = defineProps({
  body: String
})
</script>

<style scoped>
.page-foot {
  color: white;
  text-align: center;
  letter-spacing: 1px;
  font-size: 0.8rem;
}
</style>