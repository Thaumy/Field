import vuetify from "vite-plugin-vuetify"
import prismjsPlugin from "vite-plugin-prismjs"

export default defineNuxtConfig({
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
        //config CDN here
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
        '@/styles/vuetify/snackbar.styl',

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
        '@/styles/prism/light.styl'
    ],
    vite: {
        build: {
            target: "ES2022"
        },
        ssr: {
            noExternal: ['vuetify']
        },
        plugins: [
            prismjsPlugin({
                languages: [
                    'c',
                    'go', 'go-module',
                    'sql', 'coq', 'css', 'php', 'cpp',
                    'java', 'html', 'toml', 'json', 'json5', 'yaml', 'scss', 'sass', 'rust',
                    'shell', 'regex', 'latex', 'scala', 'cmake',
                    'python', 'fsharp', 'scheme', 'kotlin',
                    'haskell',
                    'javascript', 'typescript',
                    //rare usage
                    'idris', 'less', 'lisp', 'agda', 'racket', 'julia', 'graphql', 'http', 'lua'
                ]
                //TODO fix style
                //plugins: ['show-language']
            })
        ]
    }
})
