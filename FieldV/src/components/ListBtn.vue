<template>
  <v-app id="main"></v-app>
</template>

<script>
export default {
  name: "ListBtn",

  components: {  },

  data() {
    return {};
  },
};
</script>

<style scoped>
.main {
  font-size: 26px;
  line-height: 50px;

  color: #ffffff;
}

.main::before {
  font-family: "field-icon";

  margin: 12px;
  content: "\e3018";
}

/* 屏幕宽度 [ 1001 , + ) */
@media (min-width: 1001px) {
}

/* 屏幕宽度 ( - , 1000 ] */
@media (max-width: 1000px) {
}
</style>