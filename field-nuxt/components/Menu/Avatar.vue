<template>
  <div>

    <div class="avatar-zone">

      <div
          class="avatar-holder border-shadow cursor-pointer"
          v-ripple
          @click="router.push('/'+about_me)"
      >
        <img
            class="avatar"
            :src="avatarUrl"
            alt="avatar"
        />
      </div>
    </div>

  </div>
</template>

<script lang="ts" setup>

import {about_me} from "@/scripts/data/menu"
import {useRouter} from "#app"

const props =
    defineProps<{
      avatarUrl: string,
    }>()

const router = useRouter()

</script>

<style lang="stylus" scoped>

.avatar-zone
  display flex

  height 21vh
  max-height 160px
  min-height 150px

.avatar-holder
  width 10vw
  height 10vw

  max-width 100px
  max-height 100px
  margin auto

  border-radius 100px

.avatar
  width 10vw
  height 10vw
  max-width 100px
  max-height 100px
  border-radius 100px

</style>