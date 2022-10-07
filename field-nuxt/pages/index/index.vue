<template>
  <div>

    <transition-group>
      <f-lazy
          v-for="id in ids"
          :key="id"
      >
        <f-data
            :provider="async () => {
              //TODO wired！bigint not work here！
              await preparePost(BigInt(id))
              return getPost(BigInt(id))
            }"
            v-slot="it"
        >
          <PostCard
              :key="id"
              class="cursor-pointer"
              hide-body
              :post="it.post"
              :cover-url="it.additional.coverUrl"
              :summary="it.additional.summary"
              :is-generated-summary="it.additional.isGeneratedSummary"
              :view-count="it.additional.viewCount"
              :comment-count="it.comments.length"
              :is-archived="it.additional.isArchived"
              :is-scheduled="it.additional.isScheduled"
              :topics="it.additional.topics"
              @click="router.push('/'+it.post.id)"
          />
        </f-data>
      </f-lazy>
    </transition-group>

  </div>
</template>

<script lang="ts" setup>

import {log} from "@/scripts/util/debug"
import FData from "@/components/field/f-data.vue"
import FLazy from "@/components/field/f-lazy.vue"
import PostCard from "@/components/PostCard/PostCard.vue"
import {useAsyncData, useRoute, useRouter} from "#app"
import {getPost, getAllPostId, preparePost, prepareAllPostId} from "~/scripts/data/post"

const router = useRouter()

const ids = useAsyncData('get_all_post_id', async () => {
  await prepareAllPostId()//TODO
  return getAllPostId()
}).data

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
