<template>
  <div>

    <f-data
        :provider="async () => {
          await preparePost(postId)
          return getPost(postId)
        }"
        v-slot="current"
    >
      <div class="holder border-radius-all transition-standard">
        <!--TODO 此实现不优雅-->
        <f-data
            :provider="async ()=> {
            await preparePost(current.additional.prevId)
            return getPost(current.additional.prevId)
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
            await preparePost(current.additional.nextId)
            return getPost(current.additional.nextId)
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
      </div>
    </f-data>
  </div>
</template>

<script lang="ts" setup>

import {removeHtmlTags} from "@/scripts/util/text"
import FData from "@/components/field/f-data.vue"
import {notNullOrUndefined} from "@/scripts/util/nullable"
import {useRoute, useRouter} from "#app"

const props =
    defineProps<{
      postId: bigint
    }>()

const route = useRoute()
const router = useRouter()

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