<template>
  <div>

    <div
        class="border-radius-all"
        :style=
            "coverUrl?`background-image:url(${coverUrl});background-size:cover`:''"
    >
      <div
          class="preview"
          :style="coverUrl?withCoverStyle:noneCoverStyle"
      >
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
    </div>

  </div>
</template>

<script setup lang="ts">
import {ref, defineProps, toRefs, PropType} from "vue";
import ScheduleChip from "@/components/tip/ScheduleChip.vue";
import ReadTimeTip from "@/components/tip/ReadTimeTip.vue";
import ArchiveChip from "@/components/tip/ArchiveChip.vue";

let props = defineProps({
  title: String,
  summary: String,
  coverUrl: String,
  isSchedule: Boolean,
  isArchive: Boolean,
})

const withCoverStyle = ref({
  'backdrop-filter': 'blur(10px)',
  'background': 'rgba(30, 30, 30, 0.9)'
})

const noneCoverStyle = ref({
  'background': 'rgba(30, 30, 30, 1)'
})
const backgroundStyle =
    ref({})

</script>

<style scoped>

.title {
  font-size: 24px;
}

.title-chips {
  display: flex;
  align-items: center;
}

.summary {
  font-size: 0.9rem;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;

  padding-left: 18px;
  padding-right: 18px;
}

.preview {
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

</style>