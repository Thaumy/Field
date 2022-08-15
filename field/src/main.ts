import App from './App.vue'
import hljs from 'highlight.js'
import vuetify from './plugins/vuetify'
import {createApp} from 'vue'
import {loadFonts} from './plugins/webfontloader'

import '@/styles/dark/com.css'
import '@/styles/global/el.css'
import '@/styles/global/doc.css'
import '@/styles/global/font.css'
import '@/styles/global/more.css'
import '@/styles/global/color.css'
import '@/styles/global/border.css'
import 'highlight.js/styles/atom-one-dark.css'

loadFonts()

createApp(App)
    .use(app =>
        app.directive('hljs', {
            mounted(el) {
                let blocks = el.querySelectorAll('pre code')
                for (let i = 0; i < blocks.length; i++)
                    hljs.highlightElement(blocks[i]);
            }
        })
    )
    .use(vuetify)
    .mount('#app')
