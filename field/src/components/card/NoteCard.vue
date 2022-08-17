<template>
  <div class="Card margin-bottom bE-black border-radius-all">
    <div onclick="up()" class="contain cursor-pointer border-radius-all">
      <div class="NoteContent border-radius-all">
        {{ body }}
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import {defineComponent} from "vue";

export default defineComponent({
  name: "NoteCard",
  props: ['body'],
})
</script>

<style scoped>

.NoteContent {
  padding-top: 8px;
  padding-bottom: 10px;
  padding-left: 16px;
  padding-right: 16px;

  font-size: 16px;
  font-weight: 500;
  line-height: 28px;
  word-break: break-word;
}

</style>