<template>
  <div>

    <div
        class="read-time-bar border-shadow"
    >
      <div style="margin-left:1%">
        {{ genText() }}
      </div>

      <v-icon
          icon="mdi-timer-sand"
          size="18px"
          style="align-self: center"
      />
    </div>

  </div>
</template>

<script setup lang="ts">
import {defineProps, ref} from "vue";

const props = defineProps({
  targetText: {
    type: String,
    default: ''
  },
})

function genText(): string {
  if (props.targetText?.length < 120)
    return "几秒读完"
  else {
    const pureText = props.targetText//TODO 未经优化的正则
        .replace(/[，,。.《》（(）)！!“”‘’？?/\s\n]/g, '')//空白和常用标点去除
        .replace(/<script[^>]*>(.|\n)*?<\/script>/g, '')//脚本标签
        .replace(/<style>(.|\n)*<\/style>/g, '')//样式标签
        .replace(/<([^>]|\n)+>/g, '')//其他标签
        .replace(/&#*\w+;/g, '')//去除转义

    const words = Math.round(pureText.length / 100) * 100//精确到百字
    const sec = pureText.length / 10

    if (sec < 12)
      return `几秒读完`
    else
      return `约 ${words} 字 / 阅读成本 ${Math.round(sec / 60)} 分钟`
  }
}


//TODO auto calculus...
</script>

<style lang="stylus" scoped>

.read-time-bar
  margin auto
  display flex
  justify-content space-between

  background rgba(0 143 11 20%)

  //day mode
  //background rgb(52 165 61)

  padding 3px

  font-size 15px
  border-radius 3px
</style>