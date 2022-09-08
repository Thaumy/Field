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
      <CommentZone
          class="margin-bottom"
          :post-id="dataCollection[0].post.id"
          :comments="dataCollection[0].comments"
      />
      <SwitchZone
          class="margin-bottom"
          :prev="dataCollection[0].prevTitle"
          :next="dataCollection[0].nextTitle"
      />
    </div>

  </div>
</template>

<script lang="ts" setup>

import {inject} from "vue"
import CommentZone from "@/components/CommentZone/CommentZone.vue"
import SwitchZone from "@/components/btn/SwitchZone.vue"
import PostCard from "../PostCard/PostCard.vue"
import {PostFullData} from "@/components/PostCard/type"
import {useRouter} from "vue-router"

const props =
    defineProps<{
      dataCollection: PostFullData[]
    }>()

const showGlobalSnackbar: any = inject('showGlobalSnackbar')

if (props.dataCollection.length === 0) {
  showGlobalSnackbar('mdi-alert-rhombus', '404 NOT FOUND / 已重定向至首页。', 'red', 5000)
  useRouter().push('/')
}

</script>

<style lang="stylus" scoped>

.snackbar-text
  width fit-content
  margin auto
  color white

</style>