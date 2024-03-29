<template>
  <div>

    <f-card class="margin-bottom">
      <img
          alt="_"
          style="width:100%;display:block"
          :src="coverUrl"
          v-if="coverUrl&&hideBody"
      />
      <div :style="genBackground()" class="transition-standard">
        <div :style="genBackgroundFilter()" class="transition-inherit">
          <Preview
              :title="title"
              :summary=summary
              :show-summary="hideBody||(!hideBody&&!isGeneratedSummary)"
              :is-generated-summary="isGeneratedSummary"
              v-if="title"
          >
            <template v-slot:title-right-slot>
              <ScheduleChip v-if="isScheduled&&!hideBody"/>
              <ArchiveChip v-if="isArchived&&!hideBody"/>
              <CommentCountChip
                  :count="commentCount"
                  v-if="commentCount!==0&&hideBody"
              />
            </template>

            <template v-slot:summary-right-slot v-if="hideBody">
              <ModifyTimeChip
                  style="align-self:end"
                  :modify-time="modifyTime"
                  v-if="modifyTimeVisibility()"
              />
              <CreateTimeChip
                  style="align-self:end"
                  :create-time="createTime"
                  :date-only="true"
              />
            </template>

            <template v-slot:bottom-slot v-else>
              <!--此间隔在没有概要时渲染以改善视觉效果-->
              <div class="mt-1" v-if="!(hideBody||(!hideBody&&!isGeneratedSummary))"/>
              <ReadTimeBar
                  :target-text="body"
                  v-if="body&&!hideBody"
              />
            </template>
          </Preview>
        </div>
      </div>

      <Body
          :body="body"
          :create-time="createTime"
          :modify-time="modifyTime"
          v-if="body&&!hideBody||!title"
      >
      <template v-slot:bottom-slot>
        <div class="flex flex-wrap justify-start">
          <TopicChip class="mr-1" v-for="topic in topics" :topic="topic"/>
        </div>
        <div class="flex flex-wrap justify-end">
          <CommentCountChip
              :count="commentCount"
              v-if="commentCount!==0"
          />
          <ViewCountChip
              :count="viewCount"
              v-if="viewCount!==0"
          />
          <ModifyTimeChip
              :modify-time="modifyTime"
              :active="modifyTimeVisibility()"
              v-if="secTimespan(modifyTime,createTime)>7200"
          />
          <CreateTimeChip :create-time="createTime"/>
        </div>
      </template>
      </Body>
    </f-card>

  </div>
</template>

<script lang="ts" setup>

import {secTimespan} from "@/scripts/util/time"
import TopicChip from "@/components/chip/TopicChip.vue"
import ArchiveChip from "@/components/chip/ArchiveChip.vue"
import ScheduleChip from "@/components/chip/ScheduleChip.vue"
import ViewCountChip from "@/components/chip/ViewCountChip.vue"
import CreateTimeChip from "@/components/chip/CreateTimeChip.vue"
import ModifyTimeChip from "@/components/chip/ModifyTimeChip.vue"
import CommentCountChip from "@/components/chip/CommentCountChip.vue"
import FCard from "@/components/field/f-card.vue"
import Body from "./Body.vue"
import Preview from "./Preview.vue"
import ReadTimeBar from "./ReadTimeBar.vue"

const props = withDefaults(
    defineProps<{
      title: string | null,
      body: string,
      createTime: Date,
      modifyTime: Date,
      coverUrl: string | null,
      summary: string | null,
      isGeneratedSummary: boolean,
      viewCount: number,
      commentCount: number,
      isArchived: boolean,
      isScheduled: boolean,
      topics: string[],
      hideBody: boolean,
    }>(), {
      title: null,
      coverUrl: null,
      summary: null,
      isGeneratedSummary: false,
      topics: () => [],
      hideBody: false
    }
)

function genBackgroundFilter() {
  if (props.coverUrl)
    return {
      'backdrop-filter': 'blur(10px) brightness(1.2)',
      'background-color': 'rgba(var(--v-theme-background),0.82)'
    }
  else {
    if (props.body && !props.hideBody)
      return {
        'backdrop-filter': 'invert(0.05)'
      }
    else
      return {}
  }
}

function genBackground() {
  const coverUrl = props.coverUrl
  const body = props.body && !props.hideBody

  if (coverUrl)
    return {
      'background-image': `url(${coverUrl})`,
      'background-position': body ? 'center' : 'bottom',
      'background-size': 'cover'
    }
  else
    return {
      'background-color': 'rgb(var(--v-theme-surface))'
    }
}

function modifyTimeVisibility() {
  const createTime = props.createTime
  const modifyTime = props.modifyTime

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

<style lang="stylus" scoped>
</style>