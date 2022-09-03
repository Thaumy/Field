<template>
  <div>

    <div class="about-zone">
      <div class="text cursor-pointer" v-html="info"></div>
    </div>
    <!--
        <div class="outline"
             :style="outlineStyle"
             v-ripple
             @click="outlineClick"
        >

          <div class="info cursor-pointer" v-html="info"></div>
      </div>
      -->

  </div>
</template>

<script lang="ts" setup>
import {defineProps, ref} from "vue";

defineProps({info: String})

/*
const outlineStyle = ref({
  'border-color': 'transparent'
})

function outlineClick() {
  outlineStyle.value = {'border-color': 'rgba(1, 153, 255, 1)'}
  //TODO 通过导航自动判断恢复性
  setTimeout(
      () => outlineStyle.value = {'border-color': 'transparent'},
      200)
}*/
</script>

<style lang="stylus" scoped>

.about-zone
  margin-top 6px
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

/*
.outline
  display flex

  margin auto
  margin-top 8px
  margin-bottom 8px

  border-width 1.4px
  border-style solid
  border-radius 4px

  width 94%

  transition all 0.2s ease

.info
  color grey
  align-self center
  text-align center

  margin auto
  webFontLoader-size 0.6rem
*/
</style>