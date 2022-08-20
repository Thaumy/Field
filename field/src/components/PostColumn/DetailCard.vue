<template>
  <div>

    <div class="card margin-bottom border-radius-all border-line">

      <NoneBodyPreview
          :title="title"
          :summary="summary"
          :cover-url="coverUrl"
          :create-time="createTime"
          :comment-count="commentCount"
          v-if="!body"/>

      <Preview
          :title="title"
          :summary="summary"
          :cover-url="coverUrl"
          :is-archive="isArchive"
          :is-schedule="isSchedule"
          v-if="body&&title"
      />

      <Body v-if="body" :body="body" :create-time="createTime"/>
      <!--
          :style="coverUrl?`background-size:cover;background-image: url(${coverUrl})`:''"
      <SwitchBtn :prev="prevTitle" :next="nextTitle" v-if="body"/>
  --></div>

  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";

import SwitchBtn from "@/components/btn/SwitchBtn.vue";
import NoneBodyPreview from "./NoneBodyPreview.vue"
import Preview from "./Preview.vue";
import Body from "@/components/PostColumn/Body.vue";

export default defineComponent({
  name: "PostCard",
  props: {
    coverUrl: String,
    title: String,
    summary: String,
    body: String,
    createTime: Date,
    modifyTime: Date,
    commentCount: Number,
    prevTitle: String,
    nextTitle: String,
    isSchedule: Boolean,
    isArchive: Boolean,
  },
  components: {
    Body,
    Preview,
    SwitchBtn,
    NoneBodyPreview
  },
  data() {
  }

})
</script>

<style scoped>
.card {
  width: 100%;
  overflow: hidden;
}

</style>

<style scoped>
.card {
  /* 颜色模式 */
  /*
  background: rgba(40, 40, 40, 1.00);*/
}
</style>