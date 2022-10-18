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
import {useAsyncData, useRoute, useRouter} from "#app"

const props =
    defineProps<{
      currentPostId: bigint
    }>()

const route = useRoute()
const router = useRouter()

const prev_post = await (async () => {
  const {handler: getPrevPost} = await (async () => {
    if (process.server)
      return import("@/scripts/data/server/api/post/get_prev/handler")
    else
      return import("@/scripts/data/client/api/post/get_prev/handler")
  })()
  const post = await getPrevPost({CurrentId: props.currentPostId})
  if (post.Ok) {
    return post.Data
  } else {
    return null
  }
})()

const next_post = await (async () => {
  const {handler: getNextPost} = await (async () => {
    if (process.server)
      return import("@/scripts/data/server/api/post/get_next/handler")
    else
      return import("@/scripts/data/client/api/post/get_next/handler")
  })()
  const post = await getNextPost({CurrentId: props.currentPostId})
  if (post.Ok) {
    return post.Data
  } else {
    return null
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