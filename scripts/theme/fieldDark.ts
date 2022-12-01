import {ThemeDefinition} from "vuetify/dist/vuetify";

export const fieldDark: ThemeDefinition = {
    dark: true,
    variables: {
        'medium-emphasis-opacity': 0.6,
        'high-emphasis-opacity': 0.9,
    },
    colors: {
        background: "#000000",
        'on-background': "#F0F0F0",//240

        surface: "#1E1E1E",//30
        'on-surface': "#F0F0F0",//240

        primary: "#0199ff",
        'on-primary': "#000000",

        secondary: "#238636",
        'on-secondary': "#F0F0F0",


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
