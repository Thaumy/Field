<template>

  <div class="List">
    <transition-group tag="div" name="barMove">
      <div class="bar"
           :key="style"
           :style="{'background':style.color}"
           v-for="style in barStyles"></div>
    </transition-group>

    <div>
      <PageListCard
          v-for="(it,index) in pages.value"
          :title="it.title"
          @click="toggleBar(index)"
      />
    </div>

    <transition-group tag="div" name="barMove">
      <div class="bar"
           :key="style"
           :style="{'background':style.color}"
           v-for="style in barStyles"></div>
    </transition-group>
  </div>

</template>

<script lang="ts">
import {defineComponent} from "vue";

import PageListCard from "./PageListCard.vue";
import {PageSet} from "../../scripts/common";

export default defineComponent({
  name: "PageList",
  components: {PageListCard},
  props: {
    pages: PageSet,
  },
  data() {
    return {
      barStyles: [] as { color: string }[],
    }
  },
  methods: {
    toggleBar(index: number) {
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


.List {
  display: grid;
  padding-bottom: 8px;
  grid-template-columns: 1% 98% 1%;
}

.bar {
  margin-top: 2px;
  margin-bottom: 2px;
  height: 6vh;
  max-height: 50px;
  min-height: 28px;
}

.barMove-move,
.barMove-enter-active,
.barMove-leave-active {
  transition: all 0.2s ease;
}

.barMove-enter-from,
.barMove-leave-to {
  opacity: 0;
  transform: scaleY(0.1);
}

.barMove-leave-active {
  position: absolute;
}
</style>