<template>
  <div>

    <div class="post-zone float-right">

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

      <!--
            <CommentZone :post-id="12384"/>

            <f-card style="width: fit-content;margin: auto">
              <SwitchBtn prev="你不知道的114514个单身技巧" next="构建pilipala应用的最佳实践"/>
            </f-card>
         -->
    </div>
  </div>
</template>

<script lang="ts" setup>
import CommentZone from "@/components/CommentZone/CommentZone.vue";
import PostCard from "../PostCard/PostCard.vue";
import FCard from "@/components/field/f-card.vue";
import SwitchBtn from "@/components/btn/SwitchBtn.vue";
import {PropType} from "vue";
import {Post} from "@/scripts/type/post";
import {Topic} from "@/scripts/type/topic";
import {PostCardData} from "@/components/PostCard/type";

defineProps({
  dataCollection: Object as PropType<PostCardData[]>
})
</script>

<style lang="stylus" scoped>
/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px)
  .post-zone
    width 76%
    max-width 1100px

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px)
  .post-zone
    width 100%

</style>