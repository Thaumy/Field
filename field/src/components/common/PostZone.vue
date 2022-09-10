<template>
  <div>

    <div v-if="dataCollection.length>1">
      <PostCard
          hide-body
          v-for="data in dataCollection"
          :post="data.post"
          :coverUrl="data.coverUrl"
          :summary="data.summary"
          :viewCount="data.viewCount"
          :commentCount="data.comments.length"
          :isArchive="data.isArchive"
          :isSchedule="data.isSchedule"
          :topics="data.topics"
          class="cursor-pointer"
          @click="$router.push('/'+data.post.id)"
      />
    </div>

    <div v-else-if="dataCollection.length===1">
      <PostCard
          :post="dataCollection[0].post"
          :coverUrl="dataCollection[0].coverUrl"
          :summary="dataCollection[0].summary"
          :viewCount="dataCollection[0].viewCount"
          :commentCount="dataCollection[0].comments.length"
          :isArchive="dataCollection[0].isArchive"
          :isSchedule="dataCollection[0].isSchedule"
          :topics="dataCollection[0].topics"
      />
      <transition-group>
        <CommentZone
            key=""
            class="margin-bottom"
            :post-id="dataCollection[0].post.id"
            :comments="dataCollection[0].comments"
            :disable-comment="dataCollection[0].disableComment"
        />
        <SwitchZone
            key=""
            class="margin-bottom"
            :post-id="dataCollection[0].post.id"
        />
      </transition-group>
    </div>

  </div>
</template>

<script lang="ts" setup>

import {defineAsyncComponent, inject, provide} from "vue"
import {PostFullData} from "@/scripts/type/post"
import {useRouter} from "vue-router"
import PostCard from "@/components/PostCard/PostCard.vue"
import {onBeforeRouteUpdate} from "vue-router"
import {
  isPostFullDataExist,
  fetchPostFullDataFromServer
} from "@/scripts/data/post"

onBeforeRouteUpdate(async (to, from, next) => {
  const id = Number(to.params.post_id_or_title)

  //如果数据不存在，从服务器获取
  if (!isPostFullDataExist(id))
    await fetchPostFullDataFromServer(id)//TODO title

  next()
})

const CommentZone = defineAsyncComponent(
    () => import("@/components/CommentZone/CommentZone.vue"))
const SwitchZone = defineAsyncComponent(
    () => import("@/components/btn/SwitchZone.vue"))

const props =
    defineProps<{
      dataCollection: PostFullData[]
    }>()

const showGlobalSnackbar: any = inject('showGlobalSnackbar')

if (props.dataCollection.length === 0) {
  showGlobalSnackbar('mdi-alert-rhombus', '404 NOT FOUND / 已重定向至首页', 'red', 5000)
  useRouter().push('/')
}

</script>

<style lang="stylus" scoped>

.v-enter-active
  transition all 0.2s ease

.v-enter-from
  transform translateY(20px)
  opacity 0

</style>