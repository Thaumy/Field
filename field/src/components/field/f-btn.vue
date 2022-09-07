<template>
  <div>

    <button
        class="f-btn border-radius-all transition-standard"
        :class="{'disabled':disabled,
                 'warning':warning,
                 'reject':reject,
                 'light':!theme.global.current.value.dark,
                 'dark':theme.global.current.value.dark}"
        @click="disabled?disableCLick():$emit('click')"
        type="submit"
        v-ripple
        v-ripple.stop="!disabled"
        v-text="text"
    />

  </div>
</template>

<script lang="ts" setup>
/*
  :style=
      "replyMode?
              {color:'black',background:'orange'}:
              {color:'rgb(var(--v-theme-on-secondary))',background:'rgb(var(--v-theme-secondary))'}"
*/
import {defineEmits, ref} from "vue"
import {useTheme} from "vuetify"

const theme = useTheme()

const emits = defineEmits<{
  (e: 'click'): void,
  (e: 'disableClick'): void
}>()

withDefaults(defineProps<{
  text: string,
  disabled: boolean
  warning: boolean
}>(), {
  disabled: false,
  warning: false
})

const reject = ref(false)

function disableCLick() {
  emits('disableClick')
  reject.value = true
  setTimeout(() => {
    reject.value = false
  }, 200)
}

</script>

<style lang="stylus" scoped>

.f-btn
  font-size 0.8rem
  line-height 0.8rem

  width 100%
  height 100%
  padding 8px
  position relative

  border-style solid
  border-width 1px
  cursor pointer

  &:hover
    filter brightness(1.1)

  &[class~=disabled]
    cursor not-allowed
    filter saturate(0.5)

  &[class~=light]
    color #ffffff
    background-color #2da44e
    box-shadow 0 1px 0 rgba(27 31 36 0.1), inset 0 1px 0 rgba(255 255 255 0.03)
    border-color rgba(27 31 36 0.15)

  &[class~=dark]
    color #ffffff
    background-color #238636
    box-shadow 0 0 transparent, 0 0 transparent
    border-color rgba(27 31 36 0.15)

  &[class~=warning]
    color #000000
    background-color orange
    box-shadow 0 0 transparent, 0 0 transparent
    border-color rgba(27 31 36 0.15)

  &[class~=reject]
    animation: finger infinite 0.2s

@keyframes finger
  0%
    transform translateX(0px)
  20%
    transform translateX(2px)
  40%
    transform translateX(-2px)
  60%
    transform translateX(2px)
  80%
    transform translateX(-2px)
  100%
    transform translateX(0px)

</style>