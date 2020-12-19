import Vue from 'vue'
import axios from 'axios'
import NaviLine from './NaviLine.vue'
import vuetify from './plugins/vuetify';

Vue.config.productionTip = false

new Vue({
  axios,
  vuetify,
  render: h => h(NaviLine)
}).$mount('#NaviLine')
