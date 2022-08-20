<template>
  <div>

    <div
        class="create-time-chip"
        :style="'color:'+createTimeColor"
    >
      {{
        createTime.getFullYear().toString().substring(2) + '-'
        + createTime.getMonth() + '-'
        + createTime.getDate()
      }}
    </div>

  </div>
</template>

<script setup lang="ts">
import {defineProps, PropType, ref} from "vue";

const props = defineProps({
  createTime: Date as PropType<Date>,
})

const createTimeColor = ref('grey')
const createTimeText = ''

</script>

<style scoped>

.create-time-chip {
  font-size: 0.8rem;
  margin-right: 3px;
}
</style>