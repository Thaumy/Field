<template>
  <div>

    <div class="holder border-radius-all transition-standard">
      <f-data
          :provider="async ()=> {
              return await getPrevPost({
                CurrentId:currentPostId
              })
          }"
          v-slot="{post}"
      >
        <div class="prev-chip">
          <v-chip
              v-if="notNullOrUndefined(post)"
              prepend-icon="mdi-chevron-left"
              color="primary"
              variant="text"
              @click="router.push('/'+post.id)"
          >
            {{ genTitle(post) }}
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
      </f-data>
      <f-data
          :provider="async ()=> {
              return await getNextPost({
                CurrentId:currentPostId
              })
          }"
          v-slot="{post}"
      >
        <div class="next-chip">
          <v-chip
              v-if="notNullOrUndefined(post)"
              append-icon="mdi-chevron-right"
              color="primary"
              variant="text"
              @click="router.push('/'+post.id)"
          >
            {{ post.Title ? post.Title : genTitle(post.body) }}
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
      </f-data>
    </div>

  </div>
</template>

<script lang="ts" setup>

import {removeHtmlTags} from "@/scripts/util/text"
import FData from "@/components/field/f-data.vue"
import {notNullOrUndefined} from "@/scripts/util/nullable"
import {useRoute, useRouter} from "#app"
import {handler as getPrevPost} from "~/scripts/data/server/api/post/get_prev/handler"
import {handler as getNextPost} from "~/scripts/data/server/api/post/get_next/handler"

const props =
    defineProps<{
      currentPostId: bigint
    }>()

const route = useRoute()
const router = useRouter()

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