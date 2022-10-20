// Styles
import '@mdi/font/css/materialdesignicons.css'
import 'vuetify/styles'

// Vuetify
import {createVuetify} from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import {fieldDark} from "@/scripts/theme/fieldDark"
import {fieldLight} from "@/scripts/theme/fieldLight"

export default defineNuxtPlugin(nuxtApp => {
    const nowHour = new Date().getHours()
    const vuetify = createVuetify(
        {
            components,
            directives,
            theme: {
                //7-18点启用light主题
                defaultTheme: nowHour > 7 && nowHour < 18 ? 'fieldLight' : 'fieldDark',
                themes: {
                    fieldDark: fieldDark,
                    fieldLight: fieldLight
                }
            }
        }
    )

    nuxtApp.vueApp.use(vuetify)
})

