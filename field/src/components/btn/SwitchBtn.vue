<template>
  <div class="pvsBtn float-left border-radius-all cursor-pointer" onclick="up()">{{ prev }}</div>
  <div class="nxtBtn float-right border-radius-all cursor-pointer" onclick="up()">{{ next }}</div>
</template>

<script lang="ts">
import {defineComponent} from "vue";
export default defineComponent({
  name: "SwitchBtn",
  props: ['prev', 'next',]
})
</script>

<style scoped>

.nxtBtn,
.pvsBtn {
  color: rgba(1, 153, 255, 1);
  font-size: 17px;
  line-height: 17px;
  text-shadow: 0px 0px 1px rgb(255, 0, 0);

  margin: 3px;
  padding: 3px;

  overflow: hidden;
  white-space: nowrap;
  text-overflow: ellipsis;
}

.pvsBtn {
  padding-right: 6px;
  padding-left: 0px;
}

.nxtBtn {
  padding-left: 6px;
  padding-right: 0px;
}

.nxtBtn::after,
.pvsBtn::before {
  font-family: 'field-icon';
  font-size: 14px;
  color: rgba(1, 153, 255, 1);
}

.nxtBtn::after {
  content: "\e3013";
}

.pvsBtn::before {
  content: "\e3012";
}
</style>