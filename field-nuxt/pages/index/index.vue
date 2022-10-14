<template>
  <div>
    <transition-group>
      <PostCard
          v-for="post in posts"
          class="cursor-pointer"
          hide-body

          :title="post.Title"
          :body="post.Body"
          :createTime="post.CreateTime"
          :modifyTime="post.ModifyTime"
          :cover-url="post.CoverUrl"
          :summary="post.Summary"
          :is-generated-summary="post.IsGeneratedSummary"
          :view-count="post.ViewCount"
          :comment-count="post.Comments.length"
          :is-archived="post.IsArchived"
          :is-scheduled="post.IsScheduled"
          :topics="post.Topics"
          @click="router.push('/'+post.Id)"
      />
      <f-lazy
          v-for="id in ids.slice(9)"
          :key="id"
      >
        <f-data
            :provider="async () => {
                return await getPost({
                  PostId:BigInt(id)
                })
            }"
            v-slot="post:Rsp"
        >
          <PostCard
              :key="id"
              class="cursor-pointer"
              hide-body

              :title="post.Title"
              :body="post.Body"
              :createTime="post.CreateTime"
              :modifyTime="post.ModifyTime"
              :cover-url="post.CoverUrl"
              :summary="post.Summary"
              :is-generated-summary="post.IsGeneratedSummary"
              :view-count="post.ViewCount"
              :comment-count="post.Comments.length"
              :is-archived="post.IsArchived"
              :is-scheduled="post.IsScheduled"
              :topics="post.Topics"
              @click="router.push('/'+post.Id)"
          />
        </f-data>
      </f-lazy>
    </transition-group>
  </div>
</template>

<script lang="ts" setup>

import FData from "@/components/field/f-data.vue"
import FLazy from "@/components/field/f-lazy.vue"
import PostCard from "@/components/PostCard/PostCard.vue"
import {useAsyncData, useRouter} from "#app"
import {handler as getPost} from "@/scripts/data/client/api/post/get/handler"
import {Rsp} from "~/scripts/data/client/api/post/get/rsp"

const router = useRouter()

const {data: post_ids} = await useAsyncData(async () => {
  const {handler: getAllPostId} =
      await import("@/scripts/data/server/api/post/get_all_id/handler")
  const ids = await getAllPostId({})
  if (ids.Ok) {
    return ids.Data.PostIds
  } else {
    //TODO
  }
})

const {data: posts} = await useAsyncData(async () => {
  const {handler: getPostBatch} =
      await import("@/scripts/data/server/api/post/get_batch/handler")
  if (post_ids.value) {
    const posts = await getPostBatch({PostIds: post_ids.value})
    if (posts.Ok) {
      return posts.Data.Collection
    } else {
      //TODO
    }
  }
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
