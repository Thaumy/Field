<template>
  <div>

    <transition>
      <div
          class="go-up-btn border-line border-radius-all"
          @click="goUp()"
          v-show="visibility"
      >
        <v-icon
            icon="mdi-arrow-up-bold"
            color="grey"
            size="small"
            style="align-self: center"
        />
      </div>
    </transition>

  </div>
</template>

<script lang="ts" setup>
import {onMounted, ref} from "vue";
import {makeThrottle} from "@/scripts/util/throttle"

const visibility = ref(false)
const goUp = () => window.scrollTo({top: 0, behavior: 'smooth'})

/* 返顶按钮淡入淡出 */
onMounted(() => {
  window.addEventListener('scroll', makeThrottle(() => {
    visibility.value = window.scrollY >= 1000
  }, 300))
})
</script>

<style lang="stylus" scoped>
.v-enter-from
.v-leave-to
  opacity 0

.v-enter-active
.v-leave-active
  transition all 0.2s

.go-up-btn
  width 32px
  height 32px
  display flex
  justify-content center
  position fixed
  z-index 1
  bottom 10%

  cursor pointer
  backdrop-filter blur(20px)

//background rgba(0 0 0 0.8)
@css {
  .go-up-btn {
    background: rgba(var(--v-theme-surface), 0.8)
  }
}

/* 屏幕宽度 [ 1491  + ) */
@media (min-width 1491px)
  .go-up-btn
    right 6%

/* 屏幕宽度 [ 1001  1490 ] */
@media (min-width 1001px) and (max-width 1490px)
  .go-up-btn
    right 2%

/* 屏幕宽度 ( -  1000 ] */
@media (max-width 1000px)
  .go-up-btn
    left 2%

</style>