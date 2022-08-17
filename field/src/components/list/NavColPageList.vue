<template>

  <div class="List">
    <transition-group tag="div" name="fade">
      <div class="bar"
           :key="style"
           :style="{'background':style.color}"
           v-for="style in barStyles"></div>
    </transition-group>

    <div>
      <NavColPageCard :title="it.title" v-for="(it,index) in pages.value" :key="index" @click="showBar(index)"/>
    </div>

    <transition-group tag="div" name="fade">
      <div class="bar"
           :key="style"
           :style="{'background':style.color}"
           v-for="style in barStyles"></div>
    </transition-group>
  </div>

</template>

<script lang="ts">
import {defineComponent} from "vue";

import NavColPageCard from "@/components/card/NavColPageCard.vue";
import {PageSet} from "../../scripts/common";

export default defineComponent({
  name: "NavColPageList",
  components: {NavColPageCard},
  props: {
    pages: PageSet,
  },
  data() {
    return {
      barStyles: [] as { color: string }[],
    }
  },
  methods: {
    showBar(index: number) {
      let final = index + 1
      let need = final - this.barStyles.length
      if (need > 0)
        for (let count = 0; count < need; count++)
          this.barStyles.splice(0, 0, {color: 'transparent'})
      else
        this.barStyles.splice(0, -need)

      this.barStyles[this.barStyles.length - 1].color = 'rgba(1, 153, 255, 1)'
    }
  },
  mounted() {
  }
})
</script>

<style scoped>

.fade-move,
.fade-enter-active,
.fade-leave-active {
  transition: all 0.2s ease;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
  transform: scaleY(0.1);
}

.fade-leave-active {
  position: absolute;
}

.List {
  display: grid;
  padding-bottom: 8px;
  grid-template-columns: 1% 98% 1%;
}

.bar {
  height: 6vh;
  max-height: 50px;
  min-height: 28px;
}

</style>