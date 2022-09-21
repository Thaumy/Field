<template>
  <div>

    <div class="holder border-radius-all transition-standard">
      <div class="prev-chip">
        <v-chip
            prepend-icon="mdi-chevron-left"
            color="primary"
            variant="text"
            @click="$router.push('/'+prev.post.id)"
            v-if="prev!==null"
        >
          {{ genTitle(prev.post) }}
        </v-chip>
        <v-chip
            color="grey"
            style="opacity:0.6"
            variant="text"
            v-else
        >
          没有更多了
        </v-chip>
      </div>

      <div class="next-chip">
        <v-chip
            append-icon="mdi-chevron-right"
            color="primary"
            variant="text"
            @click="$router.push('/'+next.post.id)"
            v-if="next!==null"
        >
          {{ genTitle(next.post) }}
        </v-chip>
        <v-chip
            color="grey"
            style="opacity:0.6"
            variant="text"
            v-else
        >
          没有更多了
        </v-chip>
      </div>
    </div>

  </div>
</template>

<script lang="ts" setup>

import {Post} from "@/scripts/type/post"
import {removeHtmlTags} from "@/scripts/util/text"
import {getNextPost, getPrevPost} from "@/scripts/data/post"

const props =
    defineProps<{
      postId: number
    }>()

const prev = getPrevPost(props.postId)
const next = getNextPost(props.postId)

function genTitle(post: Post) {
  const title = post.title
  if (title === '') {
    //取前80个字符生成标题
    //在HTML标记奇多的时候这样做会有问题，但一般不会遇到这种文章。
    const prefix = post.body.substring(0, 80)
    return removeHtmlTags(prefix).substring(0, 12) + '...'
  } else
    return title
}

</script>

<style lang="stylus" scoped>

.holder
  backdrop-filter blur(20px)
  padding-top 1px
  display flex
  justify-content end
  flex-flow wrap

.prev-chip
  margin-right auto

@css {
  .holder {
    background-color: rgba(var(--v-theme-background), 0.7)
  }
}

</style>