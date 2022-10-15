<template>
  <div>

    <PostCard
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
    />
    <transition-group>
      <f-lazy>
        <CommentZone
            key=""
            class="margin-bottom"
            :post-id="post.Id"
            :comments="post.Comments"
            :disable-comment="!post.CanComment"
        />
        <SwitchZone
            key=""
            class="margin-bottom"
            :current-post-id="post.Id"
        />
      </f-lazy>
    </transition-group>
  </div>
</template>

<script lang="ts" setup>

import {refreshNuxtData, useAsyncData, useRoute, useRouter} from "#app"
import CommentZone from "@/components/CommentZone/CommentZone.vue"
import SwitchZone from "@/components/common/SwitchZone.vue"
import {Rsp} from "~/scripts/data/client/api/post/get/rsp"
import PostCard from "@/components/PostCard/PostCard.vue"
import FLazy from "@/components/field/f-lazy.vue"
import {onBeforeMount, watch} from "vue"

const route = useRoute()
const router = useRouter()

const refresh = () => refreshNuxtData('/post/get')

const cache = new Map<bigint, Rsp>()
const post_id = BigInt(route.params.post_id.toString())
console.log(post_id)

const post = await /*await useAsyncData('/post/get',*/ (async () => {
  const {handler: getPost} = await (async () => {
    if (process.server)
      return import("@/scripts/data/server/api/post/get/handler")
    else
      return import("@/scripts/data/client/api/post/get/handler")
  })()
  const post = await getPost({Id: post_id})
  if (post.Ok) {
    cache.set(post_id, post.Data)
    return post.Data
  } else {
    //TODO 404redirect
    //await router.push('/')
    return null
  }
})()//)

watch(route, () => {
  if (post && post.Id !== post_id)
    refresh()
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
