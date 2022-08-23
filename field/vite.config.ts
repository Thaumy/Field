import {defineConfig} from 'vite'
import vue from '@vitejs/plugin-vue'
import path from 'path'
import {prismjsPlugin} from "vite-plugin-prismjs"

// https://github.com/vuetifyjs/vuetify-loader/tree/next/packages/vite-plugin
import vuetify from 'vite-plugin-vuetify'

//TODO scss variables replace via resolvers...
//import Components from 'unplugin-vue-components/vite'
//import {Vuetify3Resolver} from "unplugin-vue-components/resolvers";

// https://vitejs.dev/config/
export default defineConfig({
    resolve: {
        alias: {
            '@': path.resolve(__dirname, './src'),
        },
    },
    plugins: [
        vue(),
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
            ],
            /*TODO fix style
            plugins: ['show-language']*/
        }),
        vuetify({autoImport: true}),
        //Components({resolvers: [Vuetify3Resolver()]})
    ],
    //TODO scss variables replace via resolvers...
    /*
    css: {
        preprocessorOptions: {
            sass: {
                additionalData: "\n@import './src/styles/variables.scss';\n"
            }
        }
    }*/
})
