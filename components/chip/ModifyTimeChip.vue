<template>
  <div>

    <v-chip
        size="x-small"
        variant="text"
        :style="'color:'+genTimeColor()"
    >
      最后编辑于 {{ genTimeText() }}
    </v-chip>

  </div>
</template>

<script lang="ts" setup>

import {toRefs} from "vue"
import {formatToDateTime} from "@/scripts/util/time"

const props = withDefaults(
    defineProps<{
      modifyTime: Date,
      active: boolean
    }>(), {
      active: true
    })

function genTimeColor() {
  const modifyTime = toRefs(props).modifyTime?.value
  const active = toRefs(props).active?.value

  if (modifyTime && active) {
    const timespan = Date.now() - modifyTime.getTime()

    if (timespan < 2592000000) //if modify within a month, show blue time
      return 'rgba(var(--v-theme-primary))'
    else
      return 'grey'
  } else
    return 'grey'
}

function genTimeText() {
  const modifyTime = toRefs(props).modifyTime?.value

  if (!modifyTime)
    return

  let final: string
  if (new Date().getFullYear() === modifyTime.getFullYear())
    final = formatToDateTime(modifyTime).substring(3)
  else
    final = formatToDateTime(modifyTime)
  return final
}
</script>

<style lang="stylus" scoped>

</style>