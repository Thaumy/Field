<template>
  <div class="CommentList margin-bottom bE-white border-radius-all">

    <CommentCard v-for="item in comments" :comment='item'/>

  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";

import CommentCard from "./CommentCard.vue";

export default defineComponent({
  name: "CommentList",
  components: {CommentCard},
  data() {
    return {
      comments: [
        {
          id: 1000,
          user: '小品',
          body: '这是一条评论！',
          replyTo: null,
          siteUrl: 'https://www.thaumy.cn',
          avatarUrl: null,
          createTime: "22-08-11 | 01:34"
        },
        {
          id: 1001,
          user: 'Thaumy',
          body: '贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴',
          replyTo: 1000,
          siteUrl: 'https://www.thaumy.cn',
          avatarUrl: null,
          createTime: "22-08-12 | 02:12"
        },
        {
          id: 1002,
          user: '小品',
          body: '不许贴贴！',
          replyTo: 1000,
          siteUrl: 'https://www.thaumy.cn',
          avatarUrl: null,
          createTime: "22-08-13 | 03:51"
        },
        {
          id: 1003,
          user: 'Fubuki',
          body: 'moemoemoemoemoemoemoemoemoemoemoemoe',
          replyTo: null,
          siteUrl: null,
          avatarUrl: null,
          createTime: '22-08-13 | 05:15'
        }]
    }
  }
})
</script>

<style scoped>

.CommentList {
  /* 颜色模式 */
  background: rgba(0, 0, 0, 0.4);
}

.CommentList {
  width: 100%;
  overflow: hidden;

  backdrop-filter: saturate(180%) blur(20px);
}

</style>