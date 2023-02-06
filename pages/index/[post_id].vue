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
          <SwitchZone
              class="margin-bottom"
              :prev-post-id="searchPrevPostId(post_id)"
              :next-post-id="searchNextPostId(post_id)"
          />
        </f-lazy>
      </transition-group>
    </div>

  </div>
</template>

<script lang="ts" setup>

import {refreshNuxtData, useRoute, useRouter, useState} from "#app"
import CommentZone from "@/components/CommentZone/CommentZone.vue"
import SwitchZone from "@/components/common/SwitchZone.vue"
import PostCard from "@/components/PostCard/PostCard.vue"
import FLazy from "@/components/field/f-lazy.vue"
import {onMounted, watch} from "vue"
import {Rsp} from "@/ws/client/api/post/get_one/rsp"

const route = useRoute()
const router = useRouter()

//const refresh = () => refreshNuxtData('/post/get_one')

const post_id = (() => {
  try {
    return route.params.post_id.toString()
  } catch (_) {
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

const post = await (async () => {
  if (!post_id)
    return null
  else {
    const cache = useState<Rsp | null>(`post:${post_id}`, () => null)
    if (cache.value) {
      return cache.value
    } else {
      const {handler: getPost} = await (async () => {
        if (process.server)
          return import("@/ws/server/api/post/get_one/handler")
        else
          return import("@/ws/client/api/post/get_one/handler")
      })()
      const post = await getPost({Id: post_id})
      if (post.Ok) {
        cache.value = post.Data
      } else {
        cache.value = null
      }
      return cache.value
    }
  }
})()

/*
watch(route, () => {
  if (post && post.Id !== post_id)
    refresh()
})
*/

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

function searchPrevPostId(current_id: string) {
  console.log(post_ids)
  const index = post_ids.indexOf(current_id)
  console.log(current_id)
  console.log(index)
  if (index >= 0 && index + 1 < post_ids.length) {
    return post_ids[index + 1]
  } else {
    return "-1"
  }
}

function searchNextPostId(current_id: string) {
  console.log(post_ids)
  const index = post_ids.indexOf(current_id)
  console.log(current_id)
  console.log(index)
  if (index >= 0 && index - 1 >= 0) {
    return post_ids[index - 1]
  } else {
    return "-1"
  }
}

</script>

<style lang="stylus" scoped>

.v-leave-active
.v-enter-active
  transition all 0.3s ease

.v-enter-from
  opacity 0
  transform translateX(50px)

</style>
