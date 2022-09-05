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
      />
    </div>
    <div v-else>
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
      <!--
        prevTitle: {
          type: String,
          default: null
        },
        nextTitle: {
          type: String,
          default: null
        },
      -->
      <SwitchZone
          class="margin-bottom"
          :prev="dataCollection[0].prevTitle"
          :next="dataCollection[0].nextTitle"
      />
    </div>

  </div>
</template>

<script lang="ts" setup>

import {onBeforeMount, PropType} from "vue";
import CommentZone from "@/components/CommentZone/CommentZone.vue";
import SwitchZone from "@/components/btn/SwitchZone.vue";
import PostCard from "../PostCard/PostCard.vue";
import {PostFullData} from "@/components/PostCard/type";

defineProps({
  dataCollection: Object as PropType<PostFullData[]>,
})

</script>

<style lang="stylus" scoped>

</style>