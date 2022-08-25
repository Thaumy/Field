<template>
  <div>

    <div class="f-horizontal-tabs">

      <div
          class="tab cursor-pointer"
          v-for="(item,index) in tabs"
          :style="{'grid-column-start':index+1}"
          @click="$emit('tabClick',item);toggleBar(index)"
      >
        {{ item.title }}
      </div>

      <transition-group>
        <div
            class="bar"
            key="bar"
            :style="{'grid-column-start':barPosition}"
        />
      </transition-group>

    </div>

  </div>
</template>

<script lang="ts" setup>
import {ref, defineProps, PropType} from "vue";

defineEmits<{ (e: 'tabClick', item: { title: string }): void }>()

const props = defineProps({
  tabs: Object as PropType<{ title: string }[]>
})

const barPosition = ref(1)

function toggleBar(index: number) {
  barPosition.value = index + 1
}
</script>

<style lang="stylus" scoped>
.tab
  font-size 0.8rem
  margin-left 4px
  margin-right 4px

.f-horizontal-tabs
  display grid

.bar
  margin-left 2px
  margin-right 2px
  height 2px
  background rgba(1, 153, 255, 1)

.v-move
.v-enter-active
.v-leave-active
  transition all 0.2s ease

.v-enter-from
.v-leave-to
  transform scaleX(0.1)
  opacity 0

</style>