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

<script setup lang="ts">
import {defineProps, PropType, toRefs} from "vue";
import {formatToDate, formatToDateTime} from "@/scripts/date"

const props = defineProps({
  modifyTime: Object as PropType<Date>,
  active: {
    type: Boolean,
    default: true
  }
})

function genTimeColor() {
  const modifyTime = toRefs(props).modifyTime?.value
  const active = toRefs(props).active?.value

  if (modifyTime && active) {
    const timespan = Date.now() - modifyTime.getTime()

    if (timespan < 2592000000) //if modify within a month, show blue time
      return 'rgb(0 196 255 / 80%)'
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

<style scoped>

</style>