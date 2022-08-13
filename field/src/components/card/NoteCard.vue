<template>
  <div class="Card M bE-black bRds">
    <div onclick="up()" class="contain cur bRds">
      <div class="NoteContent bRds">
        {{ body }}
      </div>
    </div>
  </div>
</template>

<script>
import '@/styles/card/common.css'

export default {
  name: "NoteCard",
  props: ['body'],
}
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