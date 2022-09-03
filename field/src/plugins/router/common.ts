import {
    createWebHashHistory,
    createWebHistory,
    createRouter
} from "vue-router"

import PostZone from '@/components/PostZone/PostZone.vue'
import {post_data} from "@/scripts/data/post";
import {getPostById} from "@/scripts/data/post";

export default createRouter({
    scrollBehavior: () => ({top: 0}),
    history: createWebHistory(),
    routes: [
        {
            path: '/',
            component: PostZone,
            props: {dataCollection: post_data.value},
            //meta: {transition: 'slide-left'},
        },
        {
            path: '/:post_id',
            component: PostZone,
            props:
                route => ({
                    dataCollection: [
                        getPostById(Number(route.params.post_id))
                    ]
                }),
            //meta: {transition: 'slide-left'},
        },
    ],
})
