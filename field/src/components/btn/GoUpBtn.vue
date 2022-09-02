<template>
  <div>

    <transition>
      <div
          class="go-up-btn border-line border-radius-all transition-standard"
          @click="goUp()"
          v-show="visibility"
          v-ripple
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

  cursor pointer
  backdrop-filter blur(20px)

@css {
  .go-up-btn {
    background: rgba(var(--v-theme-surface), 0.8)
  }
}

</style>