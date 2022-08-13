import 'vuetify/styles'
import './styles/el.css'
import './styles/doc.css'
import './styles/img.css'
import './styles/font.css'
import './styles/more.css'
import './styles/color.css'
import './styles/border.css'
import './styles/transition.css'
import './styles/markdown-dark.css'
import 'highlight.js/styles/atom-one-dark.css'
import {createApp} from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import hljs from 'highlight.js'
import {loadFonts} from './plugins/webfontloader'

loadFonts()

createApp(App)
    .use(app =>
        app.directive('hljs', {
            mounted(el) {
                let blocks = el.querySelectorAll('pre code');
                for (let i = 0; i < blocks.length; i++) {
                    hljs.highlightElement(blocks[i]);
                }
            }
        })
    )
    .use(vuetify)
    .mount('#app')
