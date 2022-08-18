<template>

  <div class="Card margin-bottom border-radius-all">
    <div class="contain border-radius-all">

      <div class="title-flex">
        <div class="title">{{ title }}</div>
        <div class="title-chips">
          <ScheduleChip/>
          <ArchiveChip/>
        </div>
      </div>
      <div class="summary">{{ summary }}</div>

      <ReadTimeTip/>

      <div class="Content markdown-body" v-html="body"></div>
      <SwitchBtn :prev="prevTitle" :next="nextTitle"/>

    </div>
  </div>

</template>

<script lang="ts">
import {defineComponent} from "vue";

import ReadTimeTip from "@/components/tip/ReadTimeTip.vue";
import ScheduleChip from "@/components/tip/ScheduleChip.vue";
import ArchiveChip from "@/components/tip/ArchiveChip.vue";
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
    ScheduleChip,
    ArchiveChip,
    ReadTimeTip
  },
  data() {
  }

})
</script>

<style scoped>
.title-flex {
  display: flex;
  padding-top: 12px;
  justify-content: space-between;
  padding-right: 8px;
  padding-bottom: 8px;
}

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

.title {
  font-size: 24px;
  line-height: 24px;
}

.title-chips {
  display: flex;
}

img {
  border-top-left-radius: 3px;
  border-top-right-radius: 3px;
  margin-bottom: -5px;
}

.summary {
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
  padding-left: 12px;
  padding-right: 12px;

  font-size: 15px;
  line-height: 22px;
  letter-spacing: 1px;
  word-break: break-word;
}
</style>
