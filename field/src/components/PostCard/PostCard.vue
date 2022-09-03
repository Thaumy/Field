<template>
  <div>

    <f-card
        class="margin-bottom"
    >
      <img
          alt="_"
          style="width:100%;display:block"
          :src="coverUrl"
          v-if="coverUrl&&!post.body"
      />
      <div :style="genBackground()" class="transition-standard">
        <div :style="genBackgroundFilter()" class="transition-inherit">
          <Preview
              :title=post.title
              :summary=summary
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
import ReadTimeBar from "@/components/PostCard/ReadTimeBar.vue";
import ArchiveChip from "@/components/chip/ArchiveChip.vue";
import TopicChip from "@/components/chip/TopicChip.vue";
import ModifyTimeChip from "@/components/chip/ModifyTimeChip.vue";
import CreateTimeChip from "@/components/chip/CreateTimeChip.vue";
import Preview from "./Preview.vue";
import Body from "@/components/PostCard/Body.vue";
import FCard from "@/components/field/f-card.vue";
import {Post} from "@/scripts/type/post";
import CommentCountChip from "@/components/chip/CommentCountChip.vue";
import {Topic} from "@/scripts/type/topic";
import {Comment} from "@/scripts/type/comment";

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
  topics: {
    type: Object as PropType<Topic[]>,
    default: <Topic[]>[]
  },
  hideBody: {
    type: Boolean,
    default: false
  }
})

//defineEmits<{ (e: 'postClick', post: Post): void }>()

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