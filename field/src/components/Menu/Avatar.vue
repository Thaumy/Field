<template>
  <div>

    <div class="avatar-zone">

      <div
          class="avatar-holder border-shadow cursor-pointer"
          v-ripple
          @click="$router.push('/')"
      >
        <img
            class="avatar"
            :src="avatarUrl"
            alt="avatar"
        />
      </div>
      <!--
            <div

                v-ripple
                class="avatar-outline"
                :style="outlineStyle"
                @click="showOutline()"
            >
              <img
                  alt="avatar"
                  :src="avatarUrl"
                  class="avatar border-shadow cursor-pointer"
              />
            </div>    -->
    </div>

  </div>
</template>

<script lang="ts" setup>
import {ref, defineProps} from "vue";

const props = defineProps({
  avatarUrl: String,
})
/*
const outlineStyle = ref({
  'border-color': 'transparent'
})

function showOutline() {
  outlineStyle.value = {
    'border-color': 'rgba(1, 153, 255, 1)'
  }
  setTimeout(() => outlineStyle.value = {'border-color': 'transparent'}, 200)
}*/
</script>

<style lang="stylus" scoped>

.avatar-zone
  display flex

  height 21vh
  max-height 160px
  min-height 150px

.avatar-holder
  width 10vw
  height 10vw

  max-width 100px
  max-height 100px
  margin auto

  border-radius 100px

.avatar
  width 10vw
  height 10vw
  max-width 100px
  max-height 100px
  border-radius 100px

/*
.avatar-outline
  margin auto
  display flex

  width 11vw
  height 11vw
  max-width 108px
  max-height 108px

  border-width 2.6px
  border-style solid
  border-radius 100px

  transition all 0.2s ease

.avatar
  align-self center

  width 10vw
  height 10vw
  max-width 100px
  max-height 100px

  margin auto
  border-radius 100px
*/
</style>