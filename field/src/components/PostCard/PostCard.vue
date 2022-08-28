<template>
  <div>

    <f-card class="margin-bottom">
      <v-img
          :eager=true
          :src="coverUrl"
          v-if="coverUrl&&!post.body"
      />
      <div :style=genPreviewBgStyle()>
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
            <ScheduleChip v-if="isSchedule"/>
            <ArchiveChip v-if="isArchive"/>
          </template>

          <template v-slot:summary-right-slot v-if="!post.body">
            <ModifyTimeChip :modify-time="post.modifyTime" style="align-self: end" v-if="modifyTimeVisibility()"/>
            <CreateTimeChip :create-time="post.createTime" style="align-self: end" date-only="true"/>
          </template>

          <template v-slot:bottom-slot>
            <ReadTimeBar :target-text="post.body" v-if="post.body"/>
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
import ScheduleChip from "@/components/tip/ScheduleChip.vue";
import ReadTimeBar from "@/components/tip/ReadTimeBar.vue";
import ArchiveChip from "@/components/tip/ArchiveChip.vue";
import TopicChip from "@/components/chip/TopicChip.vue";
import ModifyTimeChip from "@/components/chip/ModifyTimeChip.vue";
import CreateTimeChip from "@/components/chip/CreateTimeChip.vue";
import Preview from "./Preview.vue";
import Body from "@/components/PostCard/Body.vue";
import FCard from "@/components/field/f-card.vue";
import {Post} from "@/scripts/type/post";
import CommentCountChip from "@/components/tip/CommentCountChip.vue";
import {Topic} from "@/scripts/type/topic";
import {PostCardData} from "@/components/PostCard/type";

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
  const coverUrl = props.data?.coverUrl

  if (coverUrl)
    return {
      'backdrop-filter': coverUrl ? 'blur(10px)' : '',
      'background-color': 'rgba(10, 10, 10, 0.8)'
    }
  else return {}
}

function genPreviewBgStyle() {
  const coverUrl = props.data?.coverUrl
  const body = props.data?.post.body

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
  const createTime = props.data?.post.createTime
  const modifyTime = props.data?.post.modifyTime

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