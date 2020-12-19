<template>
  <v-app id="main">
    <img id="Avatar" src="http://q1.qlogo.cn/g?b=qq&nk=1951327599&s=640" />
    <div id="Name">THAUMY的小站</div>

  </v-app>
</template>

<script>


export default {
  name: "NaviLine",

  components: {  },

  data() {
    return {};
  },
};
</script>

<style scoped>
#main {
  width: 100%;
  height: 48px;

  position: fixed;

  background: rgba(0, 0, 0, 0.8);
  backdrop-filter: saturate(180%) blur(20px);
  box-shadow: 0px 0px 3px 0.2px rgba(0, 0, 0, 0.4);
}

#Avatar {
  margin: 4px;
  width: 40px;
  height: 40px;
  border-radius: 30px;
}

#Name {
  width: 20%;
  color: white;
  z-index: 1;
  font-size: 22px;

  padding-left: 12px;
  line-height: 48px;
}

/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
  #Avatar {
    display: none;
  }
}

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px) {
}
</style>