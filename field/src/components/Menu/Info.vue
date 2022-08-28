<template>
  <div>

    <div class="info-zone">

      <div class="title">{{ title }}</div>

      <div class="typing">
        <v-icon icon="mdi-format-quote-open"/>
        <span id="typing_area"/>
        <v-icon icon="mdi-format-quote-close"/>
      </div>

    </div>

  </div>
</template>

<script lang="ts" setup>
import {defineProps, onMounted, PropType} from "vue";
import Typed from "typed.js";

const props = defineProps({
  title: String,
  typing: Object as PropType<string[]>
})

onMounted(() => {
  new Typed('#typing_area', {
    strings: props.typing,
    typeSpeed: 100,
    backSpeed: 0,
    smartBackspace: true,
    loop: false
  })
})
</script>

<style lang="stylus" scoped>

.title
  font-size 21px
  font-weight 400
  letter-spacing 2px

  text-align center

.typing
  color rgba(230 230 230 80%)
  height 6vh
  max-height 50px
  min-height 30px
  width 98%

  font-size 15px

  text-align center

  margin auto

</style>