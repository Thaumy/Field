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
              :title=post.title
              :summary=summary
              :is-generated-summary="isGeneratedSummary"
              v-if=post.title
          >
            <template v-slot:title-right-slot>
              <ScheduleChip v-if="isSchedule&&!hideBody"/>
              <ArchiveChip v-if="isArchive&&!hideBody"/>
              <CommentCountChip
                  :count="commentCount"
                  v-if="commentCount!==0&&hideBody"
              />
            </template>

            <template v-slot:summary-right-slot v-if="!post.body">
              <ModifyTimeChip
                  style="align-self:end"
                  :modify-time="post.modifyTime"
                  v-if="modifyTimeVisibility()"
              />
              <CreateTimeChip
                  style="align-self:end"
                  :create-time="post.createTime"
                  :date-only="true"
              />
            </template>

            <template v-slot:bottom-slot v-else>
              <ReadTimeBar :target-text="post.body" v-if="post.body&&!hideBody"/>
            </template>
          </Preview>
        </div>
      </div>

      <Body
          :body="post.body"
          :create-time="post.createTime"
          :modify-time="post.modifyTime"
          v-if="post.body&&!hideBody||!post.title"
      >
      <template v-slot:bottom-slot>
        <div class="flex flex-wrap justify-start">
          <TopicChip class="mr-1" v-for="topic in topics" :topic="topic.name"/>
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
              :modify-time="post.modifyTime"
              :active="modifyTimeVisibility()"
              v-if="secTimespan(post.modifyTime,post.createTime)>7200"
          />
          <CreateTimeChip :create-time="post.createTime"/>
        </div>
      </template>
      </Body>
    </f-card>

  </div>
</template>

<script lang="ts" setup>

import {defineProps, onMounted, PropType} from "vue"
import {secTimespan} from "@/scripts/util/time"
import {Post} from "@/scripts/type/post"
import {Topic} from "@/scripts/type/topic"
import TopicChip from "@/components/chip/TopicChip.vue"
import ArchiveChip from "@/components/chip/ArchiveChip.vue"
import ScheduleChip from "@/components/chip/ScheduleChip.vue"
import ViewCountChip from "@/components/chip/ViewCountChip.vue"
import CreateTimeChip from "@/components/chip/CreateTimeChip.vue"
import ModifyTimeChip from "@/components/chip/ModifyTimeChip.vue"
import CommentCountChip from "@/components/chip/CommentCountChip.vue"
import Body from "./Body.vue"
import Preview from "./Preview.vue"
import ReadTimeBar from "./ReadTimeBar.vue"

const props = withDefaults(
    defineProps<{
      post: Post,
      coverUrl: string | null,
      summary: string | null,
      isGeneratedSummary: boolean,
      viewCount: number,
      commentCount: number,
      isArchive: boolean,
      isSchedule: boolean,
      topics: Topic[],
      hideBody: boolean,
    }>(), {
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
    if (props.post?.body && !props.hideBody)
      return {
        'backdrop-filter': 'invert(0.05)'
      }
    else
      return {}
  }
}

function genBackground() {
  const coverUrl = props.coverUrl
  const body = props.post?.body && !props.hideBody

  if (coverUrl)
    return {
      'background-image': `url(${coverUrl})`,
      'background-position': body ? 'center' : 'bottom',
      'background-size': 'cover',
    }
  else
    return {
      'background-color': 'rgb(var(--v-theme-surface))'
    }
}

function modifyTimeVisibility() {
  const createTime = props.post?.createTime
  const modifyTime = props.post?.modifyTime

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