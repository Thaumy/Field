<template>
  <div>
    <transition-group>
      <PostCard
          v-for="it in its"
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
      <f-lazy
          v-for="id in ids.slice(9)"
          :key="id"
      >
        <f-data
            :provider="async () => {
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

import {CachedMixin} from "@/scripts/type/mixin"
import FData from "@/components/field/f-data.vue"
import FLazy from "@/components/field/f-lazy.vue"
import PostCard from "@/components/PostCard/PostCard.vue"
import {useAsyncData, useRouter} from "#app"
import {
  getPost,
  preparePost,
} from "~/scripts/data/client/post"

const router = useRouter()

const {data: ids} = await useAsyncData(async () => {
  const {requestAllPostIdSSR} = await import("@/scripts/data/server/post")
  console.log('invoked requestAllPostIdSSR')
  let arr: bigint[] = []
  for (const id of await requestAllPostIdSSR())
    arr.push(BigInt(id))

  return arr
})

const {data: its} = await useAsyncData(async () => {
  const {requestBatchPostSSR} = await import("@/scripts/data/server/post")
  console.log('invoked requestBatchPostSSR')

  if (ids.value !== null)
    return await requestBatchPostSSR(ids.value.slice(0, 8))
})

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
