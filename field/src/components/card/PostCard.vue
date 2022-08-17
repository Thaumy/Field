<template>

  <div class="Card margin-bottom bE-black border-radius-all">
    <div class="contain border-radius-all">

      <div class="Title">{{ title }}</div>
      <div class="Summary">{{ summary }}</div>

      <ScheduleTip/>
      <ArchiveTip/>
      <ReadTimeTip/>

      <div class="Content markdown-body" v-html="body"></div>
      <SwitchBtn :prev="prevTitle" :next="nextTitle"/>

    </div>
  </div>

</template>

<script lang="ts">
import {defineComponent} from "vue";
import ScheduleTip from "@/components/tip/ScheduleTip.vue";
import ReadTimeTip from "@/components/tip/ReadTimeTip.vue";
import ArchiveTip from "@/components/tip/ArchiveTip.vue";
import SwitchBtn from "@/components/btn/SwitchBtn.vue";

export default defineComponent({
  name: "PostCard",
  props: {
    title: String,
    summary: String,
    body: String,
    prevTitle: String,
    nextTitle: String
  },
  components: {
    SwitchBtn,
    ScheduleTip,
    ArchiveTip,
    ReadTimeTip
  },

})
</script>

<style scoped>
.Card {
  width: 100%;

  overflow: hidden;
  /* 颜色模式 */
  background: rgba(40, 40, 40, 1.00);
}

.contain {
  overflow: hidden;
  width: 100%;
  border-top-left-radius: 4px;
  border-top-right-radius: 4px;
}

.Title {
  font-size: 24px;
  line-height: 24px;

  padding-left: 12px;
  padding-bottom: 8px;
}

img {
  border-top-left-radius: 3px;
  border-top-right-radius: 3px;
  margin-bottom: -5px;
}

.Summary {
  font-size: 15px;
  line-height: 20px;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;

  padding-left: 18px;
  padding-right: 18px;

  margin-bottom: 8px;
}

.Content {
  padding: 4px;
  padding-left: 8px;
  padding-right: 8px;

  font-size: 15px;
  line-height: 22px;
  letter-spacing: 1px;
  word-break: break-word;
}
</style>

<style scoped>
/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
  .Title {
    padding-top: 12px;
  }
}

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px) {
  .Title {
    padding-top: 10px;
  }
}
</style>
