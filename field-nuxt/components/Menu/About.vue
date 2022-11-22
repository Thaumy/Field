<template>
  <div>

    <div class="about-zone">
      <div
          class="text cursor-pointer"
          v-html="info"
          @click="router.push('/'+about_site_post_id)"
      />
    </div>

  </div>
</template>

<script lang="ts" setup>

import {useRouter} from "#app"

let props =
    defineProps<{
      about_site_post_id: string
      info: string
    }>()

const router = useRouter()

</script>

<style lang="stylus" scoped>

.about-zone
  margin-top 14px
  margin-bottom 12px

.text
  align-self center
  text-align center

  margin auto
  font-size 0.6rem

@css {
  .text {
    /*color grey*/
    color: rgb(var(--v-theme-on-surface), var(--v-medium-emphasis-opacity));
  }
}

</style>