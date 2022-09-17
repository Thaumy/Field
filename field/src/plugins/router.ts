import {createRouter, createWebHistory} from "vue-router"
import PostZone from '@/components/common/PostZone.vue'
import {
    getPost,
    isCached,
    getAllPost, getAllPostFromCache, getPostFromCache
}
    from "@/scripts/data/post"

export default createRouter({
    scrollBehavior: () => ({
        top: 0,
        behavior: 'smooth'
    }),
    history: createWebHistory(),
    routes: [
        {
            path: '/',
            beforeEnter: async (to, from, next) => {
                await getAllPost()
                next()
            },
            component: PostZone,
            props: _ => {
                return {dataCollection: getAllPostFromCache()}
            },
        },
        {
            path: '/:post_id',
            beforeEnter: async (to, from, next) => {
                const post_id = Number(to.params.post_id)

                //如果数据不存在，从服务器获取
                //TODO title
                if (!isCached(post_id))
                    await getPost(post_id)

                next()
            },
            component: PostZone,
            props: r => {
                const post_id = Number(r.params.post_id)
                const v = getPostFromCache(post_id)

                if (v !== null)
                    return {dataCollection: [v]}
                else
                    return {dataCollection: []}
            },
        }
    ],
})
