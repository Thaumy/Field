<template>
  <div>

    <div class="info-zone">

      <div
          class="title cursor-pointer"
          v-text="title"
          @click="router.push('/')"
      />

      <div class="typing">
        <v-icon class="quote-icon" icon="mdi-format-quote-open"/>
        <span id="typing_area"/>
        <v-icon class="quote-icon" icon="mdi-format-quote-close"/>
      </div>

    </div>

  </div>
</template>

<script lang="ts" setup>

import {onMounted} from "vue"
import Typed from "typed.js"
import {useRouter} from "#app"

const router = useRouter()

const props =
    defineProps<{
      title: string,
      typing: string[]
    }>()

onMounted(() => {
  const options = {
    strings: props.typing,
    typeSpeed: 100,
    backSpeed: 0,
    cursorChar: '_',
    smartBackspace: true,
    loop: false
  }
  new Typed('#typing_area', options)
})

</script>

<style lang="stylus" scoped>

.title
  font-size 21px
  font-weight 400
  letter-spacing 2px

  text-align center

.typing
  width 90%
  font-size 15px
  text-align center
  margin-top 6px
  margin-left auto
  margin-right auto


@css {
  .title {
    color: rgb(var(--v-theme-on-surface));
  }
  .typing {
    color: rgba(var(--v-theme-on-surface), var(--v-medium-emphasis-opacity));
  }
  .quote-icon {
    color: rgba(var(--v-theme-on-surface), var(--v-activated-opacity));
  }
}

</style>