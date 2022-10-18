<template>
  <div>

    <div v-if="post">
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
        <f-lazy key="">
          <CommentZone
              class="margin-bottom"
              :post-id="post.Id"
              :comments="post.Comments"
              :disable-comment="!post.CanComment"
          />
        </f-lazy>
        <f-lazy key="">
          <SwitchZone
              class="margin-bottom"
              :current-post-id="post.Id"
          />
        </f-lazy>
      </transition-group>
    </div>

  </div>
</template>

<script lang="ts" setup>

import {refreshNuxtData, useAsyncData, useRoute, useRouter} from "#app"
import CommentZone from "@/components/CommentZone/CommentZone.vue"
import SwitchZone from "@/components/common/SwitchZone.vue"
import {Rsp} from "~/scripts/data/client/api/post/get/rsp"
import PostCard from "@/components/PostCard/PostCard.vue"
import FLazy from "@/components/field/f-lazy.vue"
import {onBeforeMount, onMounted, watch} from "vue"

const route = useRoute()
const router = useRouter()

const refresh = () => refreshNuxtData('/post/get')

const cache = new Map<bigint, Rsp>()
const post_id = (() => {
  try {
    BigInt(route.params.post_id.toString())
  } catch (e) {
    return null
  }
})()

onMounted(async () => {
  const showGlobalSnackbar: any = inject('showGlobalSnackbar')
  if (!post) {
    await router.push('/')
    showGlobalSnackbar
    ('mdi-alert-rhombus', '404 NOT FOUND / 已重定向至首页', 'red', 5000)
  }
})

const post = await /*await useAsyncData('/post/get',*/ (async () => {
  if (!post_id)
    return null
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
  transition all 0.3s ease

.v-enter-from
  opacity 0
  transform translateX(50px)

</style>
