<template>
  <div class="CoBox M bE-white">

    <span class="text_auth L">由Thaumy最后编辑于19.04.05</span>
    <span title="MD5签名 : @MD5" class="text_mId R">004C01E</span>

    <div class="AtBox bRds-b">
      <div class="Date">19-07-12</div>
      <div class="UVCount">12345</div>
      <div class="CommentCount cur">12345</div>
      <div class="StarCount cur">12345</div>
      <div class="Time">周四 07:12</div>
      <div class="Archiv">氛归档</div>
      <div class="Label">氛标签</div>
    </div>
  </div>
</template>

<script>
export default {
  name: "CoBox"
}
</script>

<style scoped>

.CoBox {
  width: 100%;
  overflow: hidden;
  font-size: 16px;
  color: rgba(250, 250, 250, 1.00);

  border-radius: 4px;
}

#FootCoBox {
  color: white;
  text-align: center;
  letter-spacing: 1px;
  height: 100px;
}

.CoBox>.AtBox>.StarCount {
  color: rgba(250, 250, 250, 1.00);
}

.CoBox>.AtBox>.StarCount:hover {
  box-shadow: 0px 0px 3px 0.2px rgba(0, 0, 0, 0.4);
}

.CoBox>.AtBox>.CommentCount {
  color: rgba(250, 250, 250, 1.00);
}

.CoBox>.AtBox>.CommentCount:hover {
  box-shadow: 0px 0px 3px 0.2px rgba(0, 0, 0, 0.4);
}

.CoBox>.text_auth {
  margin-top: 6px;
  margin-left: 10px;

  letter-spacing: 1px;
  margin-right: 0;
}

.CoBox>.text_mId {
  font-family: 'Roboto Mono', monospace;
  letter-spacing: 2px;
  font-size: 14px;
  line-height: 14px;
  margin: 6px;

  border-radius: 4px;
}

.CoBox>.text_mId::before {
  font-family: 'field-icon';
  content: "\e3015";

  display: table-cell;
}

.CoBox {
  /* 颜色模式 */
  background: rgba(30, 30, 30, 1.00);
}

.CoBox>.AtBox>.StarCount {
  /* 颜色模式 */
  background: rgba(0,194,185,1);
}

.CoBox>.AtBox>.CommentCount {
  /* 颜色模式 */
  background: rgba(1, 153, 255, 1);
}
</style>