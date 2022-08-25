<template>
  <div>

    <transition-group class="tab-list" tag="div">
      <div class="bar"
           key="bar"
           :style="{'grid-row-start':barPosition,'grid-column-start':1}"
      />

      <div
          class="tab cursor-pointer border-radius-all"
          v-for="(item,index) in tabs"
          :style="{'grid-column-start': 2,'grid-row-start':index+1}"
          :title="item.title"
          :key="item"
          @click="$emit('tabClick',item);toggleBar(index)"
      >
        <div class="tab-title">{{ item.title }}</div>
      </div>

      <div class="bar"
           key="bar"
           :style="{'grid-row-start':barPosition,'grid-column-start':3}"
      />
    </transition-group>

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
.tab-list
  display grid
  padding-bottom 8px
  grid-template-columns 1% 98% 1%

.bar
  margin-top 2px
  margin-bottom 2px
  background rgba(1, 153, 255, 1)

.v-move
.v-enter-active
.v-leave-active
  transition all 0.2s ease

.v-enter-from
.v-leave-to
  opacity 0
  transform scaleY(0.1)

.v-leave-active
  position absolute

.tab
  display flex
  width 94%

  height 5vh
  max-height 44px
  min-height 28px

  margin auto
  margin-top 4px
  margin-bottom 4px

  font-size 17px
  letter-spacing 1px
  color rgba(230 230 230 1.00)

.tab-title
  margin-right auto
  align-self center
  margin-left auto
</style>
