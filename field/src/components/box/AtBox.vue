<template>
  <div class="AtBox bRds-b">
    <div v-if="createDate" class="Date">{{ createDate }}</div>
    <div v-if="viewCount" class="UVCount">{{ viewCount }}</div>
    <div v-if="commentCount" class="CommentCount">{{ commentCount }}</div>
    <div v-if="starCount" class="StarCount">{{ starCount }}</div>
    <div v-if="createTime" class="Time">{{ createTime }}</div>
    <div v-if="archive" class="Archiv">{{ archive }}</div>
    <div v-if="label" class="Label">{{ label }}</div>
  </div>
</template>

<script>
export default {
  name: "AtBox",
  props:
      ['createDate',
        'createTime',
        'viewCount',
        'commentCount',
        'starCount',
        'archive',
        'label',]
}
</script>

<style scoped>

.AtBox {
  width: 100%;

  overflow: hidden;
  padding-top: 3px;
  padding-bottom: 3px;
}


/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
  .AtBox {
    background-size: 20px 20px;
  }
}

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px) {
  .AtBox {
    background-size: 14px 14px;
  }
}

.AtBox > div {
  width: 21%;
  float: left;

  text-align: center;

  margin-left: 2%;
  margin-right: 2%;
  margin-top: 2px;
  margin-bottom: 2px;

  border-radius: 4px;
}

/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
  .AtBox > div {
    font-size: 0.8em;
  }
}

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px) {
  .AtBox > div {
    font-size: 0.6em;
  }
}

.AtBox > div::before {
  font-family: 'field-icon';
  padding-right: 6px;
}

.AtBox > .CommentCount,
.AtBox > .StarCount {
  transition: all 0.2s ease;
}

.AtBox > .Date::before {
  content: "\e3007";
}

.AtBox > .UVCount::before {
  content: "\e3008";
}

.AtBox > .CommentCount::before {
  content: "\e3010";
}

.AtBox > .StarCount::before {
  content: "\e3014";
}


.AtBox > .Time::before {
  content: "\e3004";
}

.AtBox > .Archiv::before {
  content: "\e3001";
}

.AtBox > .Label::before {
  content: "\e3006";
}

.CoBox > .AtBox {
  border-top-left-radius: 4px;
  border-top-right-radius: 4px;
}

.CoBox > .AtBox > .StarCount {
  color: rgba(250, 250, 250, 1.00);
}

.CoBox > .AtBox > .StarCount:hover {
  box-shadow: 0px 0px 3px 0.2px rgba(0, 0, 0, 0.4);
}

.CoBox > .AtBox > .CommentCount {
  color: rgba(250, 250, 250, 1.00);
}

.CoBox > .AtBox > .CommentCount:hover {
  box-shadow: 0px 0px 3px 0.2px rgba(0, 0, 0, 0.4);
}

.CoBox > .AtBox > .StarCount {
  /* 颜色模式 */
  background: rgba(0, 194, 185, 1);
}

.CoBox > .AtBox > .CommentCount {
  /* 颜色模式 */
  background: rgba(1, 153, 255, 1);
}

/* CoBox里的星星有不同的样式 */
.CoBox > .AtBox > .StarCount::before {
  line-height: 18px;
  content: "\e3014";
}

.CoBox > .AtBox > .CommentCount::before {
  line-height: 18px;
  content: "\e3010";
}

.CoBox > .AtBox > .StarCount {
  /* 颜色模式 */
  background: rgba(0, 194, 185, 1);
}

.CoBox > .AtBox > .CommentCount {
  /* 颜色模式 */
  background: rgba(1, 153, 255, 1);
}

.AtBox {
  /* 颜色模式 */
  color: rgba(200, 200, 200, 1.00);
  background: var(--b40);
}

</style>