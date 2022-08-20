<template>
  <div>

    <div class="card margin-bottom border-radius-all border-line">

      <v-img
          :eager=true
          :src=coverUrl
          v-if=coverUrl&&!body
      />
      <div :style=genPreviewBgStyle()>
        <Preview :title=title
                 :summary=summary
                 :style=genPreviewStyle()
                 v-if=title
        >
          <template v-slot:title-right-slot>
            <ScheduleChip v-if="isSchedule"/>
            <ArchiveChip v-if="isArchive"/>
          </template>

          <template v-slot:summary-right-slot>
            <ModifyTimeChip :modify-time="modifyTime" style="align-self: end" v-if="modifyTimeVisibility()"/>
            <CreateTimeChip :create-time="createTime" style="align-self: end" date-only="true" v-if="!body"/>
          </template>

          <template v-slot:bottom-slot>
            <ReadTimeTip word-count='6600' need-minute='5' v-if="body"/>
          </template>
        </Preview>
      </div>

      <Body :body="body"
            :create-time="createTime"
            :modify-time="modifyTime"
            v-if="body"
      >
      <template v-slot:bottom-slot>
        <div class="topic-flex">
          <TopicChip class="mr-1" topic="花花"/>
          <TopicChip class="mr-1" topic="草草"/>
          <TopicChip class="mr-1" topic="实例话题"/>
        </div>
        <div class="time-flex">
          <ModifyTimeChip
              :modify-time="modifyTime"
              :active="modifyTimeVisibility()"
              v-if="createTime.getHours() !== modifyTime.getHours()"
          />
          <CreateTimeChip :create-time="createTime"/>
        </div>
      </template>
      </Body>
      <!--<SwitchBtn :prev="prevTitle" :next="nextTitle" v-if="body"/>-->
    </div>

  </div>
</template>

<script setup lang="ts">
import {defineProps, toRefs} from "vue";

import ScheduleChip from "@/components/tip/ScheduleChip.vue";
import ReadTimeTip from "@/components/tip/ReadTimeTip.vue";
import ArchiveChip from "@/components/tip/ArchiveChip.vue";
import TopicChip from "@/components/PostColumn/TopicChip.vue";
import ModifyTimeChip from "@/components/PostColumn/ModifyTimeChip.vue";
import CreateTimeChip from "@/components/PostColumn/CreateTimeChip.vue";
import SwitchBtn from "@/components/btn/SwitchBtn.vue";
import Preview from "./Preview.vue";
import Body from "@/components/PostColumn/Body.vue";

const props = defineProps({
  coverUrl: String,
  title: String,
  summary: String,
  body: String,
  createTime: Date,
  modifyTime: Date,
  commentCount: Number,
  prevTitle: String,
  nextTitle: String,
  isSchedule: Boolean,
  isArchive: Boolean,
})

/*
function modifyTimeVisibility() {
  const createTime = toRefs(props).createTime?.value

  if (!createTime)
    return

  const timespan = Date.now() - createTime.getTime()
  return timespan > 604800000//if create within a week, hide modify time
}
*/

function genPreviewStyle() {
//:style="{'background-color': }"
  const coverUrl = toRefs(props).coverUrl?.value
  const body = toRefs(props).body?.value

  if (coverUrl)
    return {
      'backdrop-filter': coverUrl ? 'blur(10px)' : '',
      'background-color': 'rgba(10, 10, 10, 0.8)'
    }
  else return {}
}

function genPreviewBgStyle() {
  const coverUrl = toRefs(props).coverUrl?.value
  const body = toRefs(props).body?.value

  if (coverUrl)
    return {
      'background-image': `url(${coverUrl})`,
      'background-position': body ? 'center' : 'bottom',
      'background-size': 'cover',
    }
  else
    return {
      'background-color': body ? 'rgba(36, 36, 36, 1)' : 'rgba(30, 30, 30, 1)',
    }
}

function modifyTimeVisibility() {
  const createTime = toRefs(props).createTime?.value
  const modifyTime = toRefs(props).modifyTime?.value

  if (!createTime || !modifyTime)
    return

  const createTimespan = Date.now() - createTime.getTime()
  const modifyTimespan = Date.now() - createTime.getTime()


  const createWithinOneWeek = createTimespan < 604800000//if create within one week
  const noModifyWithinOneMonth = modifyTimespan > 2592000000//or NO modify within one month
  const createTimeEqToModifyTime =//or create time equal to modify time
      createTime === modifyTime

  //hide modify time
  return !(createWithinOneWeek || noModifyWithinOneMonth || createTimeEqToModifyTime)
}
</script>

<style scoped>

.topic-flex {
  display: flex;
}

.time-flex {
  display: flex;
}

.card {
  width: 100%;
  overflow: hidden;
}

</style>

<style scoped>
.card {
  /* 颜色模式 */
  /*
  background: rgba(40, 40, 40, 1.00);*/
}
</style>