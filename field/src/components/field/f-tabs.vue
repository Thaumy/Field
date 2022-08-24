<template>
  <div>

    <transition-group class="tab-list" tag="div">
      <transition-group tag='div' style="grid-column-start: 1">
        <div class="bar"
             :key="style"
             :style="{'background':style.color}"
             v-for="style in barStyles"
        />
      </transition-group>

      <transition-group tag='div' style="grid-column-start: 2">
        <f-tab
            v-for="(item,index) in tabs"
            :title="item.title"
            :key="item"
            @click="$emit('tabClick',item);toggleBar(index)"
        />
      </transition-group>

      <transition-group tag='div' style="grid-column-start: 3">
        <div class="bar"
             :key="style"
             :style="{'background':style.color}"
             v-for="style in barStyles"
        />
      </transition-group>
    </transition-group>

  </div>
</template>

<script lang="ts" setup>
import {ref, defineProps, PropType} from "vue";
import FTab from "@/components/field/f-tab.vue";

const props = defineProps({
  tabs: Object as PropType<{ title: string }[]>
})

defineEmits({
  tabClick() {

  }
})

const barStyles = ref<{ color: string }[]>([])

function toggleBar(index: number) {
  const final = index + 1
  const need = final - this.barStyles.length
  if (need > 0)
    for (let count = 0; count < need; count++)
      this.barStyles.splice(0, 0, {color: 'transparent'})
  else
    this.barStyles.splice(0, -need)

  this.barStyles[this.barStyles.length - 1].color = 'rgba(1, 153, 255, 1)'
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
  height 6vh
  max-height 44px
  min-height 28px

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
</style>
