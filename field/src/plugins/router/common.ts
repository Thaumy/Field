import {
    createWebHistory,
    createRouter
} from "vue-router"

import PostZone from '@/components/common/PostZone.vue'
import {
    fetchAllPostFullData,
    fetchPostFullDataById,
    fetchPostFullDataByTitle
} from "@/scripts/data/post"

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
            props: {
                dataCollection: fetchAllPostFullData(),
            },
        },
        {
            path: '/:post_id_or_title',
            component: PostZone,
            props: r => {
                {
                    const post_id = Number(r.params.post_id_or_title)
                    const v = fetchPostFullDataById(post_id)
                    if (v !== null)
                        return {dataCollection: [v]}
                }
                {
                    const post_title = String(r.params.post_id_or_title)
                    const v = fetchPostFullDataByTitle(post_title)
                    if (v !== null)
                        return {dataCollection: [v]}
                }
                return {dataCollection: []}
            },
        }
    ],
})
