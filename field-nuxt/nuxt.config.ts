import vuetify from "vite-plugin-vuetify"
// https://v3.nuxtjs.org/api/configuration/nuxt.config

export default defineNuxtConfig({
    /*
    build: {
        publicPath: 'test'
    },*/
    typescript: {
        strict: true,
        tsConfig: {
            compilerOptions: {
                lib: [
                    "ES2022",
                    "DOM"
                ],
                target: "ES2022",
                module: "ES2022",
                removeComments: true
            }
        }
    },
    app: {
        cdnURL: 'https://cdn.thaumy.cn',
        head: {
            title: 'THAUMY的博客',
            link: [
                {rel: 'icon', href: 'https://cdn.thaumy.cn/ui/icon.png'}
            ],
            script: [
                {src: './config/mathjax.js'},
                {
                    async: true,
                    id: "MathJax-script",
                    type: "text/javascript",
                    src: 'https://cdn.jsdelivr.net/npm/mathjax@3/es5/tex-mml-chtml.js'
                }
            ]
        }
    },
    css: [
        'vuetify/styles',
        '@/styles/global/routing.styl',
        '@/styles/global/util/border.styl',
        '@/styles/global/util/common.styl',
        '@/styles/global/util/layout.styl',
        '@/styles/global/font.styl',
        '@/styles/global/tag.styl',
        '@/styles/markdown/character.styl',
        '@/styles/markdown/common.styl',
        '@/styles/markdown/dark.styl',
        '@/styles/markdown/light.styl',
        '@/styles/markdown/transition.styl',
        '@/styles/prism/common.styl',
        '@/styles/prism/dark.styl',
        '@/styles/prism/light.styl',
        '@/styles/vuetify/snackbar.styl'
    ],
    vite: {
        build: {
            target: "ES2022",
            rollupOptions: {
                //TODO
                external: [
                    //'@mdi/font'
                ]
            }
        },
        ssr: {
            noExternal: ['vuetify']
        }
    }
    /*
    modules: [
        async (options, nuxt) => {
            nuxt.hooks.hook('vite:extendConfig', config => config.plugins.push(vuetify()))
        }
    ]*/
})
