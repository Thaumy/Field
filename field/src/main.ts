import App from './App.vue'
import {createApp} from 'vue'
import vuetify from '@/plugins/vuetify'
import router from '@/plugins/router'
import {loadFonts} from '@/plugins/webfontloader'

import '@/styles/global/font.styl'
import '@/styles/global/tag.styl'
import '@/styles/global/util/border.styl'
import '@/styles/global/util/common.styl'
import '@/styles/global/util/layout.styl'
import '@/styles/vuetify/snackbar.styl'

import '@/styles/prism/common.styl'
import "@/styles/markdown/common.styl"

import FTab from '@/components/field/f-tab.vue'
import FBtn from "@/components/field/f-btn.vue"
import FTabs from "@/components/field/f-tabs.vue"
import FCard from "@/components/field/f-card.vue"
import FSlider from "@/components/field/f-slider.vue"
import FDivider from "@/components/field/f-divider.vue"
import FSnackbar from "@/components/field/f-snackbar.vue"
import FTextarea from "@/components/field/f-textarea.vue"
import FTextRender from "@/components/field/f-text-render.vue"

loadFonts().then()

createApp(App)
    .use(router)
    .use(vuetify)
    .component('f-tab', FTab)
    .component('f-btn', FBtn)
    .component('f-tabs', FTabs)
    .component('f-card', FCard)
    .component('f-slider', FSlider)
    .component('f-divider', FDivider)
    .component('f-snackbar', FSnackbar)
    .component('f-textarea', FTextarea)
    .component('f-text-render', FTextRender)
    .mount('#app')
