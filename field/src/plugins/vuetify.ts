// Styles
import '@mdi/font/css/materialdesignicons.css'
import 'vuetify/styles'

// Vuetify
import {createVuetify} from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import {fieldDark} from "@/scripts/theme/fieldDark"
import {fieldLight} from "@/scripts/theme/fieldLight";

export default createVuetify(
    {
        components,
        directives,
        // https://vuetifyjs.com/en/introduction/why-vuetify/#feature-guides
        theme: {
            //defaultTheme: 'fieldDark',
            defaultTheme: 'fieldLight',
            themes: {
                fieldDark,
                fieldLight,
            }
        },
    }
)

