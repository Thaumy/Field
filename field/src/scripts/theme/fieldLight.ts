import {ThemeDefinition} from "vuetify/dist/vuetify";

export const fieldLight: ThemeDefinition = {
    dark: false,
    variables: {
        'medium-emphasis-opacity': 0.6,
        'high-emphasis-opacity': 0.9,
    },
    colors: {
        background: "#ffffff",
        'on-background': "#000000",//0

        surface: "#f6f6f6",//246
        'on-surface': "#000000",//0

        primary: "#0078d7",//#0199ff
        'on-primary': "#000000",

        secondary: "#2da44e",
        'on-secondary': "#ffffff",



        success: "#000000",
        'on-success': "#000000",
        warning: "#000000",
        'on-warning': "#000000",
        error: "#000000",
        'on-error': "#000000",
        info: "#000000",
        'on-info': "#000000",
    },
}
