<template>
  <div>

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

    <transition-group>
      <f-lazy
          v-for="id in post_ids.slice(9)"
          :key="id"
      >
        <f-data
            :provider="()=>getPost(id)"
            v-slot="post:Rsp"
        >
          <PostCard
              :key="id"
              class="cursor-pointer"
              hide-body

              :title="post.Title"
              :body="post.Body"
              :create-time="post.CreateTime"
              :modify-time="post.ModifyTime"
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
import {useRouter, useState} from "#app"
import {Rsp} from "@/ws/client/api/post/get_one/rsp"
import {cache} from "browserslist"

const router = useRouter()

const post_ids =
    await (async () => {
      const cache = useState<string[] | null>('all_post_id', () => null)
      if (cache.value) {
        return cache.value
      } else {
        const {handler: getAllPostId} = await (async () => {
          if (process.server)
            return import("@/ws/server/api/post/get_all_id/handler")
          else
            return import("@/ws/client/api/post/get_all_id/handler")
        })()
        const ids = await getAllPostId({})
        if (ids.Ok) {
          cache.value = ids.Data.PostIds
        } else {
          cache.value = []
        }
        return cache.value
      }
    })()

const posts = await (async () => {
  const {handler: getSomePost} = await (async () => {
    if (process.server)
      return import("@/ws/server/api/post/get_some/handler")
    else
      return import("@/ws/client/api/post/get_some/handler")
  })()
  const posts = await getSomePost({Ids: post_ids.slice(0, 9)})
  if (posts.Ok) {
    return posts.Data.Collection
  } else {
    return []
  }
})()

for (const post of posts)
  useState(`post:${post.Id}`, () => post)

async function getPost(post_id: string) {
  const cache = useState<Rsp | null>(`post:${post_id}`, () => null)
  if (cache.value) {
    return cache.value
  } else {
    const {handler: getPost} =
        await import('@/ws/client/api/post/get_one/handler')
    const post = await getPost({Id: post_id})
    if (post.Ok) {
      cache.value = post.Data
    } else {
      cache.value = null
    }
    return cache.value
  }
}

</script>

<style lang="stylus" scoped>

.v-leave-active
.v-enter-active
  transition all 0.2s ease

.v-enter-from
  transform translateX(50px) skewX(-1deg)

</style>
