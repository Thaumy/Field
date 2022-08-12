<template>
  <div class="Card M bE-black bRds">
    <div onclick="up()" class="contain cur bRds">
      <div class="NoteContent bRds">
        这是一条笔记，适合短文本发布。
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "NoteCard"
}
</script>

<style scoped>
.Card {
  width: 100%;

  overflow: hidden;
  /* 颜色模式 */
  background: rgba(40, 40, 40, 1.00);
}

.Card > .contain {
  overflow: hidden;
  width: 100%;
  border-top-left-radius: 4px;
  border-top-right-radius: 4px;
}

.Card > .contain > .Title {
  font-size: 24px;
  line-height: 24px;

  padding-left: 12px;
  padding-bottom: 8px;
}

.Card > .contain > img {
  border-top-left-radius: 3px;
  border-top-right-radius: 3px;
  margin-bottom: -5px;
}

.Card > .contain > .Summary {
  font-size: 15px;
  line-height: 20px;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;

  padding-left: 18px;
  padding-right: 18px;

  margin-bottom: 8px;
}

.Card > .contain > .Content {
  padding: 4px;
  padding-left: 8px;
  padding-right: 8px;

  font-size: 15px;
  line-height: 22px;
  letter-spacing: 1px;
  word-break: break-word;
}

.Card > .contain > .NoteContent {
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