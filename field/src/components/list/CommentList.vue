<template>
  <div class="CommentList M border-line border-radius-all">

    <CommentCard user-name="小品Pinn"
                 floor="1"
                 email="pinn@pilipala.org"
                 create-time="22-08-11 | 01:34"
                 body="这是一条评论！"/>

    <CommentCard user-name="Thaumy"
                 floor="2"
                 email="love@thaumy.cn"
                 create-time="22-08-12 | 02:12"
                 body="贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴贴"
                 reply-floor="1"
                 reply-user-name="小品Pinn"/>

    <CommentCard user-name="小品Pinn"
                 floor="3"
                 email="pinn@pilipala.org"
                 create-time="22-08-13 | 03:51"
                 body="不许贴贴！"
                 reply-floor="2"
                 reply-user-name="Thaumy"/>

  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";
import CommentCard from "@/components/card/CommentCard.vue";

export default defineComponent({
  name: "CommentList",
  components: {CommentCard}
})
</script>

<style scoped>

.CommentList {
  width: 100%;
  overflow: hidden;

  backdrop-filter: saturate(180%) blur(20px);
}

</style>