<template>

  <div class="Card M bE-black bRds">

    <div onclick="up()" class="contain cur">
      <div v-html="cover"></div>
      <div class="Title">{{ title }}</div>
      <div class="Summary">{{ summary }}</div>
      <component v-if="script" :is="'script'">{{ script }}</component>
    </div>

    <AtBox :create-date="createDate" :view-count="viewCount" :comment-count="commentCount" :star-count="starCount"/>

  </div>

</template>

<script>
import '@/styles/card/common.css'
import AtBox from "@/components/box/AtBox.vue";

export default {
  name: "PostPreviewCard",
  props: ['cover', 'title', 'summary', 'script', 'createDate', 'viewCount', 'commentCount', 'starCount'],
  components: {
    AtBox
  }
}
</script>

<style scoped>

</style>