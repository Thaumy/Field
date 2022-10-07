<template>
  <div>

    <f-data
        :provider="async () => {
          const post_id = BigInt(route.params.post_id.toString())
          await preparePost(post_id)
          return getPost(post_id)
        }"
        v-slot="it"
    >
      <PostCard
          :post="it.post"
          :cover-url="it.additional.coverUrl"
          :summary="it.additional.summary"
          :is-generated-summary="it.additional.isGeneratedSummary"
          :view-count="it.additional.viewCount"
          :comment-count="it.comments.length"
          :is-archived="it.additional.isArchived"
          :is-scheduled="it.additional.isScheduled"
          :topics="it.additional.topics"
      />
      <transition-group>
        <f-lazy key="">
          <CommentZone
              key=""
              class="margin-bottom"
              :post-id="it.post.id"
              :comments="it.comments"
              :disable-comment="it.additional.disableComment"
          />
        </f-lazy>
        <f-lazy
            :initializer="async () => {
            if(it.additional.prevId!==null)
              await preparePost(it.additional.prevId)
            if(it.additional.nextId!==null)
              await preparePost(it.additional.nextId)
          }"
            key=""
        >
          <SwitchZone
              key=""
              class="margin-bottom"
              :post-id="it.post.id"
          />
        </f-lazy>
      </transition-group>
    </f-data>

  </div>
</template>

<script lang="ts" setup>

import {getPost, preparePost} from "~/scripts/data/post"
import PostCard from "@/components/PostCard/PostCard.vue"
import CommentZone from "@/components/CommentZone/CommentZone.vue"
import SwitchZone from "@/components/common/SwitchZone.vue"
import FLazy from "@/components/field/f-lazy.vue"
import FData from "@/components/field/f-data.vue"
import {useAsyncData, useRoute} from "#app"

const route = useRoute()

</script>

<style lang="stylus" scoped>

.v-leave-active
.v-enter-active
  transition all 0.2s ease

.v-enter-from
  transform translateX(50px) skewX(-1deg)

.v-leave-to
  transform scale(0.9)
  filter blur(100px)
  height 0
  opacity 0

</style>
