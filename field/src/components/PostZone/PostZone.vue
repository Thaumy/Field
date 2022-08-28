<template>
  <div>

    <PostCard
        v-for="data in dataCollection"
        :post="data.post"
        :coverUrl="data.coverUrl"
        :summary="data.summary"
        :viewCount="data.viewCount"
        :commentCount="data.commentCount"
        :isArchive="data.isArchive"
        :isSchedule="data.isSchedule"
        :prevTitle="data.prevTitle"
        :nextTitle="data.nextTitle"
        :topics="data.topics"
    />

  </div>
</template>

<script lang="ts" setup>

import PostCard from "./PostCard.vue";
import {PropType} from "vue";
import {PostCardData} from "@/components/PostZone/type";

defineProps({
  dataCollection: Object as PropType<PostCardData[]>,
})

</script>

<style lang="stylus" scoped>

</style>