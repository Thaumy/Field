<template>
  <div>

    <div
        class="theme-toggle-btn cursor-pointer"
        @click="toggleTheme()"
        v-ripple
    >
      <v-icon
          :icon="genIcon()"
          class="btn-icon"
          color="grey"
          size="small"
      />
    </div>

  </div>
</template>

<script lang="ts" setup>

import {useTheme} from "vuetify"

const theme = useTheme()

function genIcon() {
  if (theme.global.current.value.dark)
    return 'mdi-moon-waning-crescent'
  else
    return 'mdi-white-balance-sunny'
}

function toggleTheme() {
  theme.global.name.value =
      theme.global.current.value.dark ? 'fieldLight' : 'fieldDark'
}
</script>

<style lang="stylus" scoped>

.theme-toggle-btn
  width 32px
  height 32px
  display flex
  justify-content center
  border-radius 16px


.btn-icon
  align-self center
  transition all 0.2s ease
  transform rotate(-45deg)

</style>