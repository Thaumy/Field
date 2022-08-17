<template>
  <div>

    <div class="SiderBtn float-right" onclick="ListToggle()"></div>

  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";
import SiderList from "../list/SiderList.vue";

export default defineComponent({
  name: "SiderBtn",
  components: {SiderList}
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