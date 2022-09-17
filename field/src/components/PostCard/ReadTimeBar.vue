<template>
  <div>

    <div
        class="read-time-bar border-shadow transition-standard"
        :style="genColor()"
    >
      <div style="margin-left:1%">
        {{ genText() }}
      </div>

      <v-icon
          icon="mdi-timer-sand"
          color="green"
          size="18px"
          style="align-self: center"
      />
    </div>

  </div>
</template>

<script lang="ts" setup>

import {useTheme} from "vuetify"
import {removePunctuation} from "@/scripts/util/text"

const props = withDefaults(
    defineProps<{
      targetText: string
    }>(), {
      targetText: ''
    })

function genText(): string {
  if (props.targetText?.length < 120)
    return "几秒读完"
  else {
    const pureText = removePunctuation(props.targetText)
    const words = Math.round(pureText.length / 100) * 100//精确到百字
    const sec = pureText.length / 10

    if (sec < 12)
      return `几秒读完`
    else
      return `约 ${words} 字 / 阅读成本 ${Math.round(sec / 60)} 分钟`
  }
}

function genColor() {
  if (useTheme().global.current.value.dark) {
    return {
      color: 'white',
      'background-color': 'rgba(0,255,71,0.12)'
    }
  } else {
    return {
      color: 'black',
      'background-color': 'rgba(45,164,78,0.12)'
    }
  }
}
</script>

<style lang="stylus" scoped>

.read-time-bar
  margin auto
  display flex
  justify-content space-between

  //raw light
  //background rgba(0 143 11 20%)

  //day mode
  //background rgb(52 165 61)

  padding 3px

  font-size 15px
  border-radius 3px

</style>