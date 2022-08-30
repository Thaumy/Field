<template>
  <div>

    <f-card class="margin-bottom">
      <v-img
          :eager=true
          :src="coverUrl"
          v-if="coverUrl&&!post.body"
      />
      <div :style="genPreviewBgStyle()">
        <Preview :title=post.title
                 :summary=summary
                 :style=genPreviewStyle()
                 v-if=post.title
        >
          <template v-slot:title-right-slot>

            <!--TODO body逻辑判断此时不再有效-->
            <CommentCountChip
                :comment-count="commentCount"
                v-if="commentCount!==0&&!post.body"
            />
            <ScheduleChip v-if="isSchedule&&post.body"/>
            <ArchiveChip v-if="isArchive&&post.body"/>
          </template>

          <template v-slot:summary-right-slot v-if="!post.body">
            <ModifyTimeChip
                style="align-self: end"
                :modify-time="post.modifyTime"
                v-if="modifyTimeVisibility()"
            />
            <CreateTimeChip
                style="align-self: end"
                :create-time="post.createTime"
                :date-only="true"
            />
          </template>

          <template v-slot:bottom-slot v-else>
            <ReadTimeBar :target-text="post.body"/>
          </template>
        </Preview>
      </div>

      <Body :body="post.body"
            :create-time="post.createTime"
            :modify-time="post.modifyTime"
            v-if="post.body"
      >
      <template v-slot:bottom-slot>
        <div class="flex" style="flex-wrap: wrap">
          <TopicChip class="mr-1" v-for="topic in topics" :topic="topic.name"/>
        </div>
        <div class="flex" style="flex-wrap: wrap">
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

import {defineProps, onMounted, PropType} from "vue";
import {secTimespan} from "@/scripts/util/time";
import ScheduleChip from "@/components/chip/ScheduleChip.vue";
import ReadTimeBar from "@/components/PostZone/ReadTimeBar.vue";
import ArchiveChip from "@/components/chip/ArchiveChip.vue";
import TopicChip from "@/components/chip/TopicChip.vue";
import ModifyTimeChip from "@/components/chip/ModifyTimeChip.vue";
import CreateTimeChip from "@/components/chip/CreateTimeChip.vue";
import Preview from "./Preview.vue";
import Body from "@/components/PostZone/Body.vue";
import FCard from "@/components/field/f-card.vue";
import {Post} from "@/scripts/type/post";
import CommentCountChip from "@/components/chip/CommentCountChip.vue";
import {Topic} from "@/scripts/type/topic";
import {PostCardData} from "@/components/PostZone/type";

const props = defineProps({
  post: Object as PropType<Post>,
  coverUrl: {
    type: String,
    default: null
  },
  summary: {
    type: String,
    default: null
  },
  viewCount: Number,
  commentCount: Number,
  isArchive: Boolean,
  isSchedule: Boolean,
  prevTitle: {
    type: String,
    default: null
  },
  nextTitle: {
    type: String,
    default: null
  },
  topics: {
    type: Object as PropType<Topic[]>,
    default: <Topic[]>[]
  }
})

function genPreviewStyle() {
  const coverUrl = props.coverUrl

  if (coverUrl)
    return {
      'backdrop-filter': 'blur(10px)',
      //'background-color': 'rgba(10, 10, 10, 0.8)'
      'background-color': 'rgba(var(--v-theme-background),var(--v-high-emphasis-opacity))'
    }
  else return {}
}

function genPreviewBgStyle() {
  const coverUrl = props.coverUrl
  const body = props.post?.body

  if (coverUrl)
    return {
      'background-image': `url(${coverUrl})`,
      'background-position': body ? 'center' : 'bottom',
      'background-size': 'cover',
    }
  else
    return {
      //36
      //30
      'background-color':
          body ?
              'rgb(var(--v-theme-background))' :
              'rgb(var(--v-theme-surface))',
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

<style scoped>
</style>