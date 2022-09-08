<template>
  <div>

    <div class="no-comment-holder">
      <v-chip class="content" prepend-icon="mdi-information">
        还没有评论
      </v-chip>
    </div>

  </div>
</template>

<script lang="ts" setup>


</script>

<style lang="stylus" scoped>

.no-comment-holder
  height fit-content
  display flex
  justify-content center

  .content
    color grey
    margin 30px
    align-self center

</style>