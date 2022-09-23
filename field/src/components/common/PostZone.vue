<template>
  <div>

    <div v-if="post_ids.length>1">
      <transition-group>
        <f-lazy
            v-for="post_id in post_ids"
            :key="post_id"
            :initializer="()=> preparePost(post_id)"
        >
          <f-data :provider="async ()=> getPost(post_id)" v-slot="data" key="">
            <PostCard
                key=""
                class="cursor-pointer"
                hide-body
                :post="data.post"
                :cover-url="data.additional.coverUrl"
                :summary="data.additional.summary"
                :is-generated-summary="data.additional.isGeneratedSummary"
                :view-count="data.additional.viewCount"
                :comment-count="data.comments.length"
                :is-archived="data.additional.isArchived"
                :is-scheduled="data.additional.isScheduled"
                :topics="data.additional.topics"
                @click="$router.push('/'+data.post.id)"
            />
          </f-data>
        </f-lazy>
      </transition-group>
    </div>

    <div v-else-if="post_ids.length===1">
      <f-data :provider="async ()=> getPost(post_ids[0])" v-slot="data">
        <PostCard
            :post="data.post"
            :cover-url="data.additional.coverUrl"
            :summary="data.additional.summary"
            :is-generated-summary="data.additional.isGeneratedSummary"
            :view-count="data.additional.viewCount"
            :comment-count="data.comments.length"
            :is-archived="data.additional.isArchived"
            :is-scheduled="data.additional.isScheduled"
            :topics="data.additional.topics"
        />
        <transition-group>
          <f-lazy key="">
            <CommentZone
                key=""
                class="margin-bottom"
                :post-id="data.post.id"
                :comments="data.comments"
                :disable-comment="data.additional.disableComment"
            />
          </f-lazy>
          <f-lazy
              key=""
              :initializer="
              async () => {
              if (props.post_ids.length === 1) {
                await prepareNextPost(props.post_ids[0])
                await preparePrevPost(props.post_ids[0])
              }}"
          >
            <SwitchZone
                key=""
                class="margin-bottom"
                :post-id="data.post.id"
            />
          </f-lazy>
        </transition-group>
      </f-data>
    </div>

  </div>
</template>

<script lang="ts" setup>

import {inject} from "vue"
import {useRouter} from "vue-router"
import PostCard from "@/components/PostCard/PostCard.vue"
import CommentZone from "@/components/CommentZone/CommentZone.vue"
import SwitchZone from "@/components/btn/SwitchZone.vue"
import {getPost, prepareNextPost, preparePrevPost} from "@/scripts/data/post"
import {preparePost} from "@/scripts/data/post"
import FLazy from "@/components/field/f-lazy.vue"
import FData from "@/components/field/f-data.vue"

const props =
    defineProps<{
      post_ids: number[]
    }>()

const showGlobalSnackbar: any = inject('showGlobalSnackbar')

if (props.post_ids.length === 0) {
  showGlobalSnackbar('mdi-alert-rhombus', '404 NOT FOUND / 已重定向至首页', 'red', 5000)
  useRouter().push('/')
}

</script>

<style lang="stylus" scoped>

.v-leave-active
.v-enter-active
  transition all 0.4s ease

.v-enter-from
  transform translateX(50px) skewX(-1deg)

.v-leave-to
  transform scale(0.9)
  filter blur(100px)
  height 0
  opacity 0

</style>