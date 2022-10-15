<template>
  <div>

    <PostCard
        :post="it.post"
        :cover-url="post.CoverUrl"
        :summary="post.Summary"
        :is-generated-summary="post.IsGeneratedSummary"
        :view-count="post.ViewCount"
        :comment-count="post.Comments.length"
        :is-archived="post.IsArchived"
        :is-scheduled="post.IsScheduled"
        :topics="post.Topics"
    />
    <!--
        <transition-group>
          <f-lazy key="">
            <CommentZone
                key=""
                class="margin-bottom"
                :post-id="post.Id"
                :comments="post.Comments"
                :disable-comment="post.CanComment"
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
    -->
  </div>
</template>

<script lang="ts" setup>

import PostCard from "@/components/PostCard/PostCard.vue"
import CommentZone from "@/components/CommentZone/CommentZone.vue"
import SwitchZone from "@/components/common/SwitchZone.vue"
import FLazy from "@/components/field/f-lazy.vue"
import {useAsyncData, useRoute, useRouter} from "#app"
import {Rsp} from "~/scripts/data/server/api/post/get/rsp"

const route = useRoute()
const router = useRouter()

const {data: post} = await useAsyncData(async () => {
  const {handler: getPost} =
      await import("@/scripts/data/server/api/post/get/handler")
  const post_id = BigInt(route.params.post_id.toString())
  const post = await getPost({Id: post_id})
  if (post.Ok) {
    return post.Data
  } else {
    //TODO 404redirect
    await router.push('/')
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
