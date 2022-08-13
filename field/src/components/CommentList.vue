<template>
  <div class="CommentList M bE-white bRds">
    <div class="Box bSha" onmouseover="CommentList_Over(this)" onmouseleave="CommentList_Leave(this)">
      <div class="Name">雅爱方雏丶YAMAHA</div>
      <div class="Floor cur bSha" data-f="1" data-id="12384" onclick="CommentBox.doReply(this)">1
      </div>
      <div class="Email">studio_ai@outlook.com</div>
      <div class="Time">20-09-12 | 01:34</div>
      <div class="Content">
        来自雅爱方雏的钦定！雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈雅马哈
      </div>
    </div>
    <div class="Box bSha" onmouseover="CommentList_Over(this)" onmouseleave="CommentList_Leave(this)">
      <div class="Name">SoulStar(回复)<span class="ReplyLogo"></span><span class="ReplyFloor">1F</span>雅爱方雏丶YAMAHA
      </div>
      <div class="Floor cur bSha" data-f="2" data-id="12384" onclick="CommentBox.doReply(this)">2
      </div>
      <div class="Email">studio_ai@outlook.com</div>
      <div class="Time">20-09-13 | 23:33</div>
      <div class="Content">
        雅子我爱你呀~哼哼哼啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊</div>
    </div>
    <div class="Box bSha" onmouseover="CommentList_Over(this)" onmouseleave="CommentList_Leave(this)">
      <div class="Name">Thaumy(回复)<span class="ReplyLogo"></span><span class="ReplyFloor">2F</span>SoulStar
      </div>
      <div class="Floor cur bSha" data-f="3" data-id="12384" onclick="CommentBox.doReply(this)">3
      </div>
      <div class="Email">studio_ai@outlook.com</div>
      <div class="Time">20-09-13 | 23:34</div>
      <div class="Content">我看你是欠日</div>
    </div>
  </div>
</template>

<script>
export default {
  name: "CommentList"
}
</script>

<style scoped>

.CommentList {
  width: 100%;
  overflow: hidden;

  backdrop-filter: saturate(180%) blur(20px);
}

.CommentList>.Box {
  display: grid;
  grid-template-columns: 50% 46% 4%;
  grid-template-rows: 24px 20px auto;

  padding: 4px;

  border-radius: 2px;
  margin: 4px;
}

.CommentList>.Box>.Name {
  justify-self: start;
  grid-column-start: 1;
  grid-column-end: 3;

  max-width: 93.4%;
  padding-left: 3px;

  font-size: 1.1em;
  font-weight: 400;
  line-height: 1.2em;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.CommentList .ReplyFloor {
  float: right;

  color: white;
  font-size: 12px;
  font-weight: 600;
  line-height: 18px;
  margin-top: 2px;
  padding-bottom: 1px;

  padding-left: 3px;
  padding-right: 3px;
  margin-left: 4px;
  margin-right: 4px;

  background: rgb(0, 180, 255);
  border-radius: 4px;
  box-shadow: 0px 0px 3px 0.2px rgba(0, 0, 0, 0.4);
}

.CommentList .ReplyLogo {
  display: inline;

  margin-left: 4px;
  margin-right: 4px;
}

.CommentList .ReplyLogo::before {
  font-family: 'field-icon';
  font-size: 0.88em;
  color: rgb(255, 159, 0);
  content: "\e3020";
}

.CommentList>.Box>.Time {
  justify-self: right;
  grid-column-start: 2;
  grid-column-end: 4;

  font-size: 0.7em;
  color: rgba(170, 170, 170, 1);
}

.CommentList>.Box>.Email {
  justify-self: start;
  padding-left: 3px;

  font-size: 0.7em;
  text-align: right;
  color: rgba(170, 170, 170, 1);
}

.CommentList>.Box>.Floor {
  justify-self: end;
  grid-column-start: 3;

  height: 14px;
  width: 14px;

  font-size: 0.6em;
  font-family: 'Roboto Mono', monospace;
  color: rgb(0, 0, 0);
  overflow: hidden;
  text-align: center;
  line-height: 13px;


  border-radius: 2px;

  transition: all 0.2s ease;
}

.CommentList>.Box>.Content {
  grid-column-start: 1;
  grid-column-end: 4;

  font-size: 0.9em;
  text-align: left;

  padding-top: 4px;
  padding-left: 8px;
  padding-bottom: 2px;
}

.CommentList {
  /* 颜色模式 */
  background: rgba(0, 0, 0, 0.4);
}

.CommentList>.Box {
  /* 颜色模式 */
  background: var(--b30);
}

.CommentList>.Box>.Name {
  /* 颜色模式 */
  color: var(--w220);
}

.CommentList>.Box>.Content {
  /* 颜色模式 */
  color: var(--w200);
}

.CommentList>.Box>.Time {
  /* 颜色模式 */
  color: rgba(170, 170, 170, 1);
}

.CommentList>.Box>.Floor {
  /* 颜色模式 */
  color: var(--w220);
  background: var(--b55);
}
</style>