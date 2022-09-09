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

import PostCard from "@/components/PostCard/PostCard.vue"
import {defineAsyncComponent, inject} from "vue"
import {PostFullData} from "@/scripts/type/post"
import {useRouter} from "vue-router"

const CommentZone = defineAsyncComponent({
  loader: () => import("@/components/CommentZone/CommentZone.vue"),
  delay: 100
})
const SwitchZone = defineAsyncComponent({
  loader: () => import("@/components/btn/SwitchZone.vue"),
  delay: 100
})

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