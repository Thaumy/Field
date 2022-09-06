import {
    createWebHashHistory,
    createWebHistory,
    createRouter
} from "vue-router"

import PostZone from '@/components/PostZone/PostZone.vue'
import {post_items} from "@/scripts/data/post"
import {getPostIn} from "@/scripts/type/post";

export default createRouter({
    scrollBehavior: () => ({
        top: 0,
        behavior: 'smooth'
    }),
    history: createWebHistory(),
    routes: [
        {
            path: '/',
            component: PostZone,
            props: {dataCollection: post_items.value},
        },
        {
            path: '/:post_id([0-9]*)',
            component: PostZone,
            props:
                route => ({
                    dataCollection: [
                        post_items.value.filter(x => x.post.id === Number(route.params.post_id))[0]
                    ]
                }),
        },
        {
            path: '/:unknown(.*)',
            redirect: '/'
        },
    ],
})
