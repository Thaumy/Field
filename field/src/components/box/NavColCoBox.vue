<template>

  <div class="outline"
       :style="outlineStyle"
       @click="outlineClick">

    <div class="body cursor-pointer" v-html="body"></div>

  </div>

</template>

<script lang="ts">
import {defineComponent} from "vue";

export default defineComponent({
  name: "NavColCoBox",
  props: {
    body: String,
  },
  data() {
    return {
      outlineStyle: {
        'border-color': 'transparent'
      }
    }
  },
  methods: {
    outlineClick() {
      this.outlineStyle = {'border-color': 'rgba(1, 153, 255, 1)'}
      //TODO 通过导航自动判断恢复性
      setTimeout(() => this.outlineStyle = {'border-color': 'transparent'}, 200)
    }
  }
})
</script>

<style scoped>

.outline {
  display: flex;

  margin: auto;
  margin-top: 8px;
  margin-bottom: 8px;

  border-width: 1.4px;
  border-style: solid;
  border-radius: 4px;

  width: 94%;

  transition: all 0.2s ease;
}

.body {
  align-self: center;

  text-align: center;

  margin: auto;
  margin-top: 2px;
  margin-bottom: 4px;

  font-size: 12px;
  line-height: 17px;
}

</style>