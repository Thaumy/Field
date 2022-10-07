// Styles
import '@mdi/font/css/materialdesignicons.css'
import 'vuetify/styles'

// Vuetify
import {createVuetify, useTheme} from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import {fieldDarkClient} from "@/scripts/theme/fieldDark.client"
import {fieldLightClient} from "@/scripts/theme/fieldLight.client"

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
                    fieldDark: fieldDarkClient,
                    fieldLight: fieldLightClient,
                }
            },
        }
    )

    nuxtApp.vueApp.use(vuetify)
})

