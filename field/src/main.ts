import App from './App.vue'
import {createApp} from 'vue'
import vuetify from '@/plugins/vuetify/common'
import router from "@/plugins/router/common"
import {loadFonts} from '@/plugins/webFontLoader/common'

import '@/styles/global/font.styl'
import '@/styles/global/tag.styl'
import '@/styles/global/util/border.styl'
import '@/styles/global/util/common.styl'
import '@/styles/global/util/layout.styl'
import '@/styles/vuetify/snackbar.styl'

loadFonts().then()

createApp(App)
    //.use(router)
    .use(vuetify)
    .mount('#app')
