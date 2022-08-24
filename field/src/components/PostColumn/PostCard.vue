<template>
  <div>

    <f-card class="margin-bottom">
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

          <template v-slot:summary-right-slot v-if="!body">
            <ModifyTimeChip :modify-time="modifyTime" style="align-self: end" v-if="modifyTimeVisibility()"/>
            <CreateTimeChip :create-time="createTime" style="align-self: end" date-only="true"/>
          </template>

          <template v-slot:bottom-slot>
            <ReadTimeBar :target-text="body" v-if="body"/>
          </template>
        </Preview>
      </div>

      <Body :body="body"
            :create-time="createTime"
            :modify-time="modifyTime"
            v-if="body"
      >
      <template v-slot:bottom-slot>
        <div class="flex">
          <TopicChip class="mr-1" v-for="topic in topics" :topic="topic"/>
        </div>
        <div class="flex">
          <ModifyTimeChip
              :modify-time="modifyTime"
              :active="modifyTimeVisibility()"
              v-if="secTimespan(modifyTime,createTime)>7200"
          />
          <CreateTimeChip :create-time="createTime"/>
        </div>
      </template>
      </Body>
      <!--<SwitchBtn :prev="prevTitle" :next="nextTitle" v-if="body"/>-->
    </f-card>

  </div>
</template>

<script lang="ts" setup>
import {defineProps, PropType, toRefs} from "vue";
import {secTimespan} from "@/scripts/date";

import ScheduleChip from "@/components/tip/ScheduleChip.vue";
import ReadTimeBar from "@/components/tip/ReadTimeBar.vue";
import ArchiveChip from "@/components/tip/ArchiveChip.vue";
import TopicChip from "@/components/chip/TopicChip.vue";
import ModifyTimeChip from "@/components/chip/ModifyTimeChip.vue";
import CreateTimeChip from "@/components/chip/CreateTimeChip.vue";
import SwitchBtn from "@/components/btn/SwitchBtn.vue";
import Preview from "./Preview.vue";
import Body from "@/components/PostColumn/Body.vue";
import FCard from "@/components/field/f-card.vue";

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
  topics: Object as PropType<string[]>
})

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

  const createTimespan = secTimespan(new Date(), createTime)
  const modifyTimespan = secTimespan(new Date(), modifyTime)


  const createWithinOneWeek = createTimespan < 604800//if create within one week
  const noModifyWithinOneMonth = modifyTimespan > 2592000//or NO modify within one month
  const createTimeEqToModifyTime =//or create time equal to modify time
      createTime === modifyTime

  //hide modify time
  return !(createWithinOneWeek || noModifyWithinOneMonth || createTimeEqToModifyTime)
}
</script>

<style scoped>
</style>

<style scoped>
</style>