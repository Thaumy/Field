<template>
  <div>

    <div class="sider-list">
      <div class="menu">
        <transition-group tag="div" name="barMove">
          <div class="bar"
               v-for="style in barStyles"
               :style="{'background':style.color}"
               :key="style"
          ></div>
        </transition-group>

        <div>
          <SiderListCard
              v-for="(item,index) in pages.value"
              :title="item.title"
              @click="toggleBar(index)"
          />
        </div>

        <transition-group tag="div" name="barMove">
          <div class="bar"
               v-for="style in barStyles"
               :style="{'background':style.color}"
               :key="style"
          ></div>
        </transition-group>
      </div>

      <div class="co cursor-pointer" onclick="up();">
        Thaumy的博客©2016-2023保留所有权利<br>
        基于pilipala构建<br>
        Field Theme Designed By Thaumy<br>
      </div>
    </div>

  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";
import {PageSet} from "../../scripts/common";

import SiderListCard from "./SiderListCard.vue";

export default defineComponent({
  name: "SiderList",
  components: {SiderListCard},
  props: {
    pages: PageSet
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
  }
})
</script>

<style scoped>

.sider-list {
  z-index: 10;
  padding-top: 50px;
  width: 246px;

  height: 100%;
  position: fixed;

  backdrop-filter: saturate(180%) blur(20px);
  grid-template-rows: 84% 16%;
  overflow: hidden;
}

.menu {
  margin-top: 20px;
  display: grid;
  grid-template-columns: 1% 98% 1%;
}


.bar {
  height: 5vh;
  margin-top: 2px;
  margin-bottom: 2px;
}

.co {
  width: 88%;
  text-align: center;

  margin: auto;

  font-size: 11px;
  line-height: 16px;
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

<style scoped>
/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
  .sider-list {
    display: none;
  }
}

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px) {
  .sider-list {
    display: grid;
  }
}
</style>