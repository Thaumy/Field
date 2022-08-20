<template>
  <div>

    <div
        class="border-radius-top"
        :style=
            "coverUrl?`background-image:url(${coverUrl});background-size:cover`:''"
    >
      <v-img
          class="border-radius-all"
          eager="true"
          :src="coverUrl"
          v-if="coverUrl"
      />

      <div class="none-body-preview"
           :style="coverUrl?withCoverStyle:noneCoverStyle"
      >
        <div class="title-flex">
          <div class="title">{{ title }}</div>
          <div class="title-chips">
            <CommentChip v-if="commentCount" :comment-count="commentCount"/>
          </div>
        </div>
        <div class="summary-flex">
          <div class="summary">{{ summary }}</div>
          <div class="time-flex">
            <ModifyTimeChip :modify-time="modifyTime" style="align-self: end" v-if="modifyTimeVisibility()"/>
            <CreateTimeChip :create-time="createTime" style="align-self: end" date-only="true"/>
          </div>
        </div>
      </div>

    </div>
  </div>
</template>

<script setup lang="ts">
import {ref, defineProps, toRefs, PropType} from "vue";
import CommentChip from "@/components/tip/CommentChip.vue";
import CreateTimeChip from "@/components/PostColumn/CreateTimeChip.vue";
import ModifyTimeChip from "@/components/PostColumn/ModifyTimeChip.vue";

let props = defineProps({
  title: String,
  summary: String,
  coverUrl: String,
  createTime: Date as PropType<Date>,
  modifyTime: Date as PropType<Date>,
  commentCount: Number,
})

const withCoverStyle = ref({
  'backdrop-filter': 'blur(10px)',
  'background': 'rgba(30, 30, 30, 0.8)'
})

const noneCoverStyle = ref({
  'background': 'rgba(30, 30, 30, 1)'
})

function modifyTimeVisibility() {
  const createTime = toRefs(props).createTime?.value
  const modifyTime = toRefs(props).modifyTime?.value

  if (!createTime || !modifyTime)
    return

  const createTimespan = Date.now() - createTime.getTime()
  const modifyTimespan = Date.now() - createTime.getTime()
  //if create within a week or no modify within a month, hide the modify time
  return !(createTimespan < 604800000 || modifyTimespan > 2592000000)
}
</script>

<style scoped>

.none-body-preview {
  padding: 6px;
}

.time-flex {
  display: flex;
}

.title-flex {
  display: flex;
  padding-bottom: 2px;
  padding-left: 6px;
  justify-content: space-between;
}

.title {
  font-size: 24px;
}

.title-chips {
  display: flex;
  align-items: center;
}

.summary-flex {
  display: flex;
  justify-content: space-between;
}

.summary {
  font-size: 0.9rem;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;

  padding-left: 18px;
  padding-right: 18px;
  padding-bottom: 4px;
}
</style>