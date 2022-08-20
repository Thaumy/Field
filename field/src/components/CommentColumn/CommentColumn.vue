<template>
  <div>

    <CommentList/>

  </div>
</template>

<script>
import CommentList from "./CommentList.vue";
import CommentEditor from "./CommentEditor.vue";

export default {
  name: "CommentColumn",
  components: {CommentEditor, CommentList}
}
</script>

<style scoped>

</style>