<template>
  <div id="NavCol" class="bE-white bRds">

    <div class="box bSha bRds-t">
      <div class="AvaBox">
        <div class="Ava-outline" v-bind:style="style" v-on:click="click" id="Ava-outline">
          <img class="Ava bSha cur" src="ui/img/pp512.png">
        </div>
      </div>

      <div class=" Name">THAUMY的小站</div>
      <div class="Note"><span id="note"></span></div>
    </div>

    <div class="List" id="pcNavList">
      <div class="barBox">
        <transition name="fade">
          <div class="bar" v-if="barSeen" v-bind:style="style"></div>
        </transition>
      </div>
      <div class="box">
        <PcNavCard/>
      </div>
    </div>

    <div class="Co-outline" v-bind:style="style" v-on:click="click" id="Co-outline">
      <div class="Co cur">
        Thaumy的博客©2016-2020保留所有权利<br>
        基于pilipala构建<br>
        Field Theme Designed By Thaumy<br>
      </div>
    </div>

  </div>
</template>

<script>
import PcNavCard from "@/components/PcNavCard";

export default {
  name: "NavCol",
  components: {PcNavCard}
}
</script>

<style scoped>
#NavCol {
  color: rgba(230, 230, 230, 1.00);
  transition: all 1s ease;
}

#NavCol > .box {
  margin-bottom: 8px;
}

#NavCol > .box > .AvaBox {
  display: flex;

  height: 21vh;
  max-height: 160px;
  min-height: 150px;
}

#NavCol > .box > .AvaBox > .Ava-outline {
  margin: auto;
  display: flex;

  width: 11vw;
  height: 11vw;
  max-width: 108px;
  max-height: 108px;

  border-width: 2.6px;
  border-style: solid;
  border-radius: 100px;

  transition: all 0.2s ease;
}

#NavCol > .box > .AvaBox > .Ava-outline > .Ava {
  align-self: center;

  width: 10vw;
  height: 10vw;
  max-width: 100px;
  max-height: 100px;

  margin: auto;

  border-radius: 100px;
}

#NavCol > .box > .Name {
  font-size: 21px;
  font-weight: 400;
  letter-spacing: 2px;

  text-align: center;
}

#NavCol > .box > .Note {
  height: 6vh;
  max-height: 50px;
  min-height: 30px;
  width: 98%;

  font-size: 15px;

  text-align: center;
  font-size: 15px;

  margin: auto;
}

#NavCol > .box > .Note::before {
  align-self: center;

  margin-right: 6px;
  font-family: "field-icon";
  content: '\e3010';
  font-size: 12px;
}

#NavCol > .box > .Note::after {
  align-self: center;

  margin-left: 6px;
  font-family: "field-icon";
  content: '\e3003';
  font-size: 12px;
}

#NavCol > .List {
  display: grid;
  padding-bottom: 8px;
  grid-template-columns: 1% 99%;
}

#NavCol > .List > .barBox > .bar {
  position: relative;

  height: 6vh;
  max-height: 50px;
  min-height: 28px;

  background-color: rgba(1, 153, 255, 1);
  border-radius: 2px;

  transition: all 0.2s ease;
}

#NavCol > .List > .box > .Card {
  display: flex;
  width: 94%;
  height: 6vh;
  max-height: 50px;
  min-height: 28px;

  margin-left: 2.4%;

  font-size: 17px;
  letter-spacing: 1px;
  color: rgba(230, 230, 230, 1.00);

  transition: all 0.2s ease;
}

#NavCol > .List > .box > .Card::after {
  align-self: center;

  margin-right: 3px;
  float: right;

  font-family: 'field-icon';
  content: "\e3013";
}

#NavCol > .List > .box > .Card > .contain {
  margin-right: auto;
  align-self: center;
  margin-left: 10px;
}

#NavCol > .Co-outline {
  display: flex;

  margin: auto;
  margin-top: 8px;
  margin-bottom: 8px;

  border-width: 1.4px;
  border-style: solid;
  border-radius: 4px;

  width: 94%;

  transition: all 0.2s ease;
}

#NavCol > .Co-outline > .Co {
  align-self: center;

  text-align: center;

  margin: auto;
  margin-top: 2px;
  margin-bottom: 4px;

  font-size: 12px;
  line-height: 17px;
}

/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
  #NavCol {
    width: 23%;
    min-width: 230px;
    max-width: 270px;

    position: fixed;
  }
}

/* 屏幕宽度 ( - , 1000 ] */
@media screen and (max-width: 1000px) {
  #NavCol {
    display: none;
  }
}

#NavCol {
  /* 颜色模式 */
  background: rgba(30, 30, 30, 1.00);
}
</style>