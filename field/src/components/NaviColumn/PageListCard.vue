<template>

  <div class="card cursor-pointer border-radius-all">
    <div class="contain">{{ title }}</div>
  </div>

</template>

<script lang="ts">
import {defineComponent} from "vue";

export default defineComponent({
  name: "NavColPageCard",
  props: {
    title: String
  },
  data() {
    return {
      barSeen: true,
      style: {
        top: '0vh'
      },
    }
  },
})
</script>

<style scoped>
.card {
  display: flex;
  width: 94%;

  height: 6vh;
  max-height: 44px;
  min-height: 28px;

  margin: auto;
  margin-top: 2px;
  margin-bottom: 2px;

  font-size: 17px;
  letter-spacing: 1px;
  color: rgba(230, 230, 230, 1.00);
}

.contain {
  margin-right: auto;
  align-self: center;
  margin-left: auto;
}
</style>