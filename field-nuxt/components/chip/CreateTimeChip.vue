<template>
  <div>

    <v-chip
        size="x-small"
        variant="text"
        :style="'color:'+genTimeColor()"
    >
      创建于 {{ genTimeText() }}
    </v-chip>

  </div>
</template>

<script lang="ts" setup>

import {toRefs} from "vue"
import {formatToDate, formatToDateTime} from "@/scripts/util/time"

const props = withDefaults(
    defineProps<{
      createTime: Date,
      dateOnly: boolean
    }>(), {
      dateOnly: false
    })

const createTime = toRefs(props).createTime?.value

function genTimeColor() {
  if (!createTime)
    return

  const createTimespan = Date.now() - createTime.getTime()

  if (createTimespan < 604800000)
      //if create within a week, show blue time
    return 'rgb(var(--v-theme-primary))'
  else
    return 'grey'
}

function genTimeText() {
  if (!createTime)
    return

  const formatter = (x: Date) => {
    if (toRefs(props).dateOnly?.value)
      return formatToDate(x)
    else
      return formatToDateTime(x)
  }

  let final: string
  if (new Date().getFullYear() === createTime.getFullYear())
    final = formatter(createTime).substring(3)
  else
    final = formatter(createTime)
  return final
}

</script>

<style lang="stylus" scoped>

</style>