<template>
  <div>

    <div class="holder border-radius-all transition-standard">
      <div class="prev-chip">
        <v-chip
            v-if="prev_post!==null"
            prepend-icon="mdi-chevron-left"
            color="primary"
            variant="text"
            @click="router.push('/'+prev_post.Id)"
        >
          {{ prev_post.Title ? prev_post.Title : genTitle(prev_post.Body) }}
        </v-chip>
        <v-chip
            v-else
            color="grey"
            style="opacity:0.6"
            variant="text"
        >
          没有更多了
        </v-chip>
      </div>
      <div class="next-chip">
        <v-chip
            v-if="next_post!==null"
            append-icon="mdi-chevron-right"
            color="primary"
            variant="text"
            @click="router.push('/'+next_post.Id)"
        >
          {{ next_post.Title ? next_post.Title : genTitle(next_post.Body) }}
        </v-chip>
        <v-chip
            v-else
            color="grey"
            style="opacity:0.6"
            variant="text"
        >
          没有更多了
        </v-chip>
      </div>
    </div>

  </div>
</template>

<script lang="ts" setup>

import {removeHtmlTags} from "@/scripts/util/text"
import {useRoute, useRouter, useState} from "#app"
import {Rsp} from "@/ws/client/api/post/get_one/rsp"

const props =
    defineProps<{
      prevPostId: string
      nextPostId: string
    }>()

const route = useRoute()
const router = useRouter()

const prev_post = await (async () => {
  const post_id = props.prevPostId
  if (post_id === "-1")
    return null
  else {
    const cache = <Rsp>useState(`post:${post_id}`).value
    if (cache)
      return cache
    else
      return useState(`post:${post_id}`, async () => {
        const {handler: getPost} = await (async () => {
          if (process.server)
            return import("@/ws/server/api/post/get_one/handler")
          else
            return import("@/ws/client/api/post/get_one/handler")
        })()
        const post = await getPost({Id: post_id})
        if (post.Ok) {
          return post.Data
        } else {
          return null
        }
      }).value
  }
})()

const next_post = await (async () => {
  const post_id = props.nextPostId
  if (post_id === "-1")
    return null
  else {
    const cache = <Rsp>useState(`post:${post_id}`).value
    if (cache)
      return cache
    else
      return useState(`post:${post_id}`, async () => {
        const {handler: getPost} = await (async () => {
          if (process.server)
            return import("@/ws/server/api/post/get_one/handler")
          else
            return import("@/ws/client/api/post/get_one/handler")
        })()
        const post = await getPost({Id: post_id})
        if (post.Ok) {
          return post.Data
        } else {
          return null
        }
      }).value
  }
})()

function genTitle(body: string) {
  //取前80个字符生成标题
  //在HTML标记奇多的时候这样做会有问题，但一般不会遇到这种文章。
  const prefix = body.substring(0, 80)
  return removeHtmlTags(prefix).substring(0, 12) + '...'
}

</script>

<style lang="stylus" scoped>

.holder
  backdrop-filter blur(20px)
  padding-top 1px
  display flex
  justify-content flex-end
  flex-flow wrap

.prev-chip
  margin-right auto

@css {
  .holder {
    background-color: rgba(var(--v-theme-background), 0.7)
  }
}

</style>