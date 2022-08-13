<template>

  <div class="List" id="pcNavList">
    <div class="barBox">
      <transition name="fade">
        <div class="bar" v-if="barSeen" v-bind:style="style"></div>
      </transition>
    </div>
    <div class="box">
      <PcNavCard/>
    </div>
  </div>

</template>

<script>
import PcNavCard from "@/components/PcNavCard.vue";

export default {
  name: "PcNavList",
  components: {PcNavCard}
}
</script>

<style scoped>

.List {
  display: grid;
  padding-bottom: 8px;
  grid-template-columns: 1% 99%;
}

.List > .barBox .bar {
  position: relative;

  height: 6vh;
  max-height: 50px;
  min-height: 28px;

  background-color: rgba(1, 153, 255, 1);
  border-radius: 2px;

  transition: all 0.2s ease;
}
</style>