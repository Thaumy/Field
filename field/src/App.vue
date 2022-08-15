<template>
  <v-app>
    <v-main id="main">
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
             style="float:right;
             color:white;width:100%;text-align:center;height:100px;letter-spacing:1px;line-height:24px;font-weight:400;">
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
import NavCol from "@/components/col/NavCol.vue";
import CardCol from '@/components/col/CardCol.vue'
import NavLine from "@/components/NavLine.vue";
import SiderList from "@/components/list/SiderList.vue";

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

<style scoped>

#main {
  background: url("https://cdn.thaumy.cn/ui-background/pc.jpg");
  background-size: cover;
  background-position: center;
  background-attachment: fixed;
}

#contain {
  margin: auto;
  max-width: 1160px;
}

/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
  #contain {
    padding-top: 8px;
    width: 99%;
  }
}

/* 屏幕宽度 [ 601 , 1000 ] */
@media (min-width: 601px) and (max-width: 1000px) {
  #contain {
    padding: 7px;
    padding-top: 57px;
  }
}

/* 屏幕宽度 ( - , 600 ] */
@media screen and (max-width: 600px) {
  #contain {
    padding-top: 57px;
  }
}
</style>