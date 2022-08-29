import App from './App.vue'
import {createApp} from 'vue'
import vuetify from '@/plugins/vuetify'
import {loadFonts} from '@/plugins/webfontloader'

import '@/styles/global/font.styl'
import '@/styles/global/tag.styl'
import '@/styles/global/util/border.styl'
import '@/styles/global/util/color.styl'
import '@/styles/global/util/common.styl'
import '@/styles/vuetify/snackbar.styl'

loadFonts().then()

createApp(App)
    .use(vuetify)
    .mount('#app')
