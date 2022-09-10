import {createRouter, createWebHistory} from "vue-router"

import PostZone from '@/components/common/PostZone.vue'
import {
    isPostFullDataExist,
    fetchAllPostFullData,
    fetchPostFullDataById,
    fetchPostFullDataByTitle,
    fetchPostFullDataFromServer,
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
            beforeEnter: async (to, from, next) => {
                const id = Number(to.params.post_id_or_title)

                //如果数据不存在，从服务器获取
                if (!isPostFullDataExist(id))
                    await fetchPostFullDataFromServer(id)//TODO title

                next()
            },
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
