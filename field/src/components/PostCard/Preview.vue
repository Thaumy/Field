<template>
  <div>

    <div
        class="preview"
    >
      <div class="title-flex" v-if="title">
        <div class="title">{{ title }}</div>

        <div class="title-right-slot">
          <slot name="title-right-slot"/>
        </div>
      </div>

      <div class="summary-flex" v-if="title&&summary">
        <div class="summary">{{ summary }}</div>

        <div class="summary-right-slot">
          <slot name="summary-right-slot"/>
        </div>
      </div>

      <slot name="bottom-slot"/>

    </div>

  </div>
</template>

<script setup lang="ts">
import {ref, defineProps, toRefs, PropType} from "vue";

let props = defineProps({
  title: String,
  summary: String,
  blurBg: Boolean
})

</script>

<style scoped>


.summary-flex {
  display: flex;
  justify-content: space-between;
}

.summary {
  font-size: 0.9rem;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;

  padding-left: 18px;
  padding-right: 18px;
}

.preview {
  padding: 6px;
  display: grid;
  grid-template-rows: auto 30px auto;
}

.title-flex {
  display: flex;
  padding: 2px;
  padding-left: 6px;
  justify-content: space-between;
}

.title {
  font-size: 24px;
}

.title-right-slot {
  display: flex;
  align-items: center;
}

.summary-right-slot {
  display: flex;
}
</style>