<template>
  <div id="NavCol" class="bE-white border-radius-all">

    <AvatarBox avatar="../../assets/pp512.png" title="THAUMY的小站"/>

    <NavColPageList :pages="pages"/>

    <NavColCoBox body=
                     'Thaumy的博客©2016-2020保留所有权利<br>
                      基于pilipala构建<br>
                      Field Theme Designed By Thaumy<br>'/>
  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";

import NavColPageList from "@/components/list/NavColPageList.vue";
import NavColCoBox from "../box/NavColCoBox.vue";
import AvatarBox from "../box/AvatarBox.vue";
import {PageSet} from "../../scripts/common";

export default defineComponent({
  name: "NavCol",
  components: {
    AvatarBox,
    NavColCoBox,
    NavColPageList
  },
  data() {
    return {
      pages: new PageSet([
        {id: 12345, title: '首页'},
        {id: 12346, title: '摸摸鱼'},
        {id: 12347, title: '追番'},
        {id: 12348, title: '看书'},
        {id: 12349, title: '写代码'},
        {id: 12350, title: '睡大觉'}]),
    }
  }
})
</script>

<style scoped>
#NavCol {
  color: rgba(230, 230, 230, 1.00);
}

#NavCol > .box {
  margin-bottom: 8px;
}

/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
  #NavCol {
    width: 23%;
    min-width: 230px;
    max-width: 270px;

    position: fixed;
  }
}

/* 屏幕宽度 ( - , 1000 ] */
@media screen and (max-width: 1000px) {
  #NavCol {
    display: none;
  }
}
</style>