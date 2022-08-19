<template>

  <div class="card margin-bottom border-radius-all bE-black">
    <div class="contain border-radius-all">

      <div class="none-body-preview-zone" v-if="!body">
        <div class="title-flex">
          <div class="title">{{ title }}</div>
          <div class="title-chips">
          </div>
        </div>
        <div class="summary">{{ summary }}</div>
      </div>

      <div class="preview-zone" v-if="body">
        <div class="title-flex">
          <div class="title">{{ title }}</div>
          <div class="title-chips">
            <ScheduleChip v-if="isSchedule"/>
            <ArchiveChip v-if="isArchive"/>
          </div>
        </div>
        <div class="summary">{{ summary }}</div>
        <ReadTimeTip word-count='6600' need-minute='5'/>
      </div>

      <div class="content markdown-body" v-html="body" v-if="body"></div>
      <!--
      <SwitchBtn :prev="prevTitle" :next="nextTitle" v-if="body"/>
-->
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
    nextTitle: String,
    isSchedule: Boolean,
    isArchive: Boolean,
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
.none-body-preview-zone {
  padding: 6px;
  background: rgba(30, 30, 30, 1.00);
}

.preview-zone {
  padding: 6px;
  display: grid;
  grid-template-rows: auto 30px auto;
}

.title-flex {
  display: flex;
  padding: 2px;
  padding-left: 6px;
  justify-content: space-between;
}

.card {
  width: 100%;

  overflow: hidden;
}

.contain {
  overflow: hidden;
  width: 100%;
  border-top-left-radius: 4px;
  border-top-right-radius: 4px;
}

.title {
  font-size: 24px;
}

.title-chips {
  display: flex;
  align-items: center;
}

img {
  border-top-left-radius: 3px;
  border-top-right-radius: 3px;
  margin-bottom: -5px;
}

.summary {
  font-size: 15px;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;

  padding-left: 18px;
  padding-right: 18px;
}

.content {
  padding: 12px;

  font-size: 15px;
  line-height: 22px;
  letter-spacing: 1px;
  word-break: break-word;
}
</style>

<style scoped>
.card {
  /* 颜色模式 */
  background: rgba(40, 40, 40, 1.00);
}

.contain {
  /* 颜色模式 */
  /*
  background: rgba(30, 30, 30, 1.00);*/
}

.title {
  /* 颜色模式 */
  color: rgba(240, 240, 240, 1.00);
}

.summary {
  /* 颜色模式 */
  color: rgba(210, 210, 210, 1.00);
}

.content {
  /* 颜色模式 */
  color: rgba(240, 240, 240, 1.00);
  background: rgba(30, 30, 30, 1.00);
}
</style>