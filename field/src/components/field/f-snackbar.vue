<template>
  <div>

    <v-snackbar
        content-class="snackbar"
        v-model="visibility"
        :timeout="_timeout"
        location=""
        variant="text"
        @click="visibility=false"
    >
      <v-chip
          class="border-line"
          style="background-color:rgb(var(--v-theme-surface))"
          size="large"
          :color="_color"
      >
        <v-icon :icon="_icon" size="small" class="mr-1"/>
        {{ _text }}
      </v-chip>
    </v-snackbar>

  </div>
</template>

<script lang="ts" setup>

import {ref} from "vue"

const visibility = ref(false)
const _text = ref('')
const _color = ref('')
const _timeout = ref(0)
const _icon = ref('')

defineExpose({
  show(icon: string, text: string, color: string, timeout = 2000) {
    _icon.value = icon
    _text.value = text
    _color.value = color
    _timeout.value = timeout
    visibility.value = true
  }
})

</script>

<style lang="stylus" scoped>

.snackbar-text
  font-size 1rem
  width fit-content
  margin auto
  color white

</style>