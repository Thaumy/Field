<template>
  <v-app>
    <v-main>
      <div id="fixed">
        <NavLine/>
        <SiderList/>

        <div class="Shadow" onclick="ListToggle()"></div>
        <div class="upBtn bE-black bRds" style="display: none" onclick="upBtn()"></div>
      </div>
      <div id="contain">
        <NavCol/>
        <CardCol/>
        <div id="IllustCo"
             style="float:right;color:white;width:100%;text-align:center;height:100px;letter-spacing:1px;line-height:24px;font-weight:400;">
          Banishment<br>
          PixivID:75993030<br>
          <a href="http://beian.miit.gov.cn/" target="_blank"
             style="color: rgba(255,255,255,0.6);font-size: 14px;text-decoration: none;">鲁ICP备2021005067</a>
        </div>
      </div>
    </v-main>
  </v-app>
</template>

<script>
import CardCol from './components/CardCol.vue'
import NavCol from "@/components/NavCol";
import NavLine from "@/components/NavLine";
import SiderList from "@/components/SiderList";

export default {
  name: 'App',

  components: {
    SiderList,
    NavLine,
    NavCol,
    CardCol,
  },

  data: () => ({
    //
  }),
}
</script>

<style>
html::-webkit-scrollbar {
  display: none;
}

body > #contain {
  margin: auto;
  max-width: 1160px;
}

body {
  font-family: 'Noto Sans SC', sans-serif;
  font-weight: 300;

  margin: 0;
}

html {
  background-image: url("https://cdn.thaumy.cn/ui-background/pc.jpg");
  background-size: cover;
  background-position: center;
  background-attachment: fixed;
}

/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
  body > #contain {
    padding-top: 8px;
    width: 99%;
  }
}

/* 屏幕宽度 [ 601 , 1000 ] */
@media (min-width: 601px) and (max-width: 1000px) {
  body > #contain {
    padding: 7px;
    padding-top: 57px;
  }
}

/* 屏幕宽度 ( - , 600 ] */
@media screen and (max-width: 600px) {
  body > #contain {
    padding-top: 57px;
  }
}
</style>