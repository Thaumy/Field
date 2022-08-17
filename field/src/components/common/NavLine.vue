<template>
  <div><!--防止外部样式干涉-->

    <div :style="{'top':top.toString()+'px'}"
         class="NavLine float-left margin-bottom border-shadow"
         v-show="show"
    >

      <div
          class="cursor-pointer border-radius-all"
          onclick="up()"
      >
        <img class="Avatar border-shadow" src="../../assets/pp512.png">
        <div class=" Name">THAUMY的小站</div>
      </div>

      <SiderBtn/>
      <SiderList :pages="pages"/>
    </div>

  </div>
</template>

<script lang="ts">
import {defineComponent} from 'vue'
import {makeDebounce} from "../../scripts/debounce";
import SiderBtn from "../btn/SiderBtn.vue";
import SiderList from "../list/SiderList.vue";
import {PageSet} from "../../scripts/common";

export default defineComponent({
  name: "NavLine",
  components: {SiderBtn, SiderList},
  data() {
    return {
      pages: new PageSet([
        {id: 12345, title: '首页'},
        {id: 12346, title: '摸摸鱼'},
        {id: 12347, title: '追番'},
        {id: 12348, title: '看书'},
        {id: 12349, title: '写代码'},
        {id: 12350, title: '睡大觉'}]),
      show: true,
      top: 0,
    }
  },
  methods: {},
  mounted() {
    /* 触发宽度外，收起NavLine */
    {
      let prev = 0
      let next = 0
      window.addEventListener('scroll', makeDebounce(() => {
        next = window.scrollY
        if (next < 50) {
          this.top = -next
        } else {
          this.top = next < prev ? 0 : -50//向下滚动收起，向上滚动展开
        }
        prev = next
      }, 100))
    }
  }
})
</script>

<style scoped>
.NavLine {
  height: 50px;
  width: 100%;
  z-index: 10;
  position: fixed;
  overflow: hidden;

  background: rgba(0, 0, 0, 0.8);
  backdrop-filter: saturate(180%) blur(20px);

  transition: all 0.1s ease;
}

.Name {
  float: left;

  font-size: 20px;
  font-weight: 400;
  letter-spacing: 4px;
  line-height: 50px;
  color: rgba(250, 250, 250, 1);
}

.Avatar {
  float: left;

  width: 42px;
  height: 41px;
  margin: 4px 10px 4px 10px;

  border-radius: 50px;
}
</style>

<style scoped>
/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
  .NavLine {
    display: none;
  }
}

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px) {
  .NavLine {
    display: unset;
  }
}
</style>
