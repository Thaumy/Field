<template>
  <div>

    <div class="CommentList margin-bottom border-line border-radius-all">

      <CommentEditor/>
      <div v-for="item in comments">
        <v-divider style="margin: auto" length="98%"/>
        <CommentCard :comment='item'/>
      </div>
    </div>


  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";

import CommentCard from "./CommentCard.vue";
import CommentEditor from "./CommentEditor.vue";

export default defineComponent({
  name: "CommentList",
  components: {CommentEditor, CommentCard},
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
  background: var(--b30);
}

.CommentList {
  width: 100%;
  overflow: hidden;
}

</style>