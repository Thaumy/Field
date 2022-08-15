<template>

  <div class="Card M bE-black border-radius-all">

    <div onclick="up()" class="contain cursor-pointer">
      <div v-html="cover"></div>
      <div class="Title">{{ title }}</div>
      <div class="Summary">{{ summary }}</div>
      <component v-if="script" :is="'script'">{{ script }}</component>
    </div>

    <AtBox :create-date="createDate" :view-count="viewCount" :comment-count="commentCount" :star-count="starCount"/>

  </div>

</template>

<script lang="ts">
import {defineComponent} from "vue";
import AtBox from "@/components/box/AtBox.vue";

export default defineComponent({
  name: "PostPreviewCard",
  props: ['cover', 'title', 'summary', 'script', 'createDate', 'viewCount', 'commentCount', 'starCount'],
  components: {
    AtBox
  }
})
</script>

<style scoped>

/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
  .Card > .contain > .Title {
    padding-top: 12px;
  }
}

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px) {
  .Card > .contain > .Title {
    padding-top: 10px;
  }
}

.Card {
  width: 100%;

  overflow: hidden;
  /* 颜色模式 */
  background: rgba(40, 40, 40, 1.00);
}

.contain {
  overflow: hidden;
  width: 100%;
  border-top-left-radius: 4px;
  border-top-right-radius: 4px;
}

.Title {
  font-size: 24px;
  line-height: 24px;

  padding-left: 12px;
  padding-bottom: 8px;
}

img {
  border-top-left-radius: 3px;
  border-top-right-radius: 3px;
  margin-bottom: -5px;
}

.Summary {
  font-size: 15px;
  line-height: 20px;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;

  padding-left: 18px;
  padding-right: 18px;

  margin-bottom: 8px;
}

.Content {
  padding: 4px;
  padding-left: 8px;
  padding-right: 8px;

  font-size: 15px;
  line-height: 22px;
  letter-spacing: 1px;
  word-break: break-word;
}
</style>