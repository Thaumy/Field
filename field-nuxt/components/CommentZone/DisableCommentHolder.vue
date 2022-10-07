<template>
  <div>

    <div class="disable-comment-holder">
      <v-chip class="content" prepend-icon="mdi-minus-circle">
        您尚未达到发表评论所需的权限级别
      </v-chip>
    </div>

  </div>
</template>

<script lang="ts" setup>


</script>

<style lang="stylus" scoped>

.disable-comment-holder
  height fit-content
  display flex
  justify-content center

  .content
    color grey
    margin 30px
    align-self center

</style>
