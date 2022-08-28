import App from './App.vue'
import {createApp} from 'vue'
import vuetify from '@/plugins/vuetify'
import {loadFonts} from '@/plugins/webfontloader'

import '@/styles/dark/com.css'
import '@/styles/global/el.css'
import '@/styles/global/font.css'
import '@/styles/global/more.css'
import '@/styles/global/color.css'
import '@/styles/global/border.css'
import '@/styles/vuetify/snackbar.styl'

loadFonts().then()

createApp(App)
    .use(vuetify)
    .mount('#app')
