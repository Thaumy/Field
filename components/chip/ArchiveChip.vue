<template>
  <div>

    <v-chip
        class="archive-chip"
        color="orange"
        size="small"
        @click.stop="showGlobalSnackbar('mdi-archive','当前文章已归档 / 不受维护的内容','orange')"
    >
      <v-icon icon="mdi-archive"/>
    </v-chip>

  </div>
</template>


<script setup lang="ts">

import {inject} from "vue"

const showGlobalSnackbar = inject('showGlobalSnackbar')

</script>

<style lang="stylus" scoped>

.archive-chip
  margin-left 2px
  margin-right 2px

</style>
