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
  max-height: 50px;
  min-height: 28px;

  margin-left: 2.4%;

  font-size: 17px;
  letter-spacing: 1px;
  color: rgba(230, 230, 230, 1.00);

  transition: all 0.2s ease;
}

.contain {
  margin-right: auto;
  align-self: center;
  margin-left: auto;
}
</style>