import {createRouter, createWebHistory} from "vue-router"
import PostZone from '@/components/common/PostZone.vue'
import {
    preparePost,
    prepareAllPostId,
    getPost,
    getAllPostId,
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
                await prepareAllPostId()
                next()
            },
            component: PostZone,
            props: _ => {
                return {post_ids: getAllPostId()}
            },
        },
        {
            path: '/:post_id',
            beforeEnter: async (to, from, next) => {
                //TODO title route support
                const post_id = Number(to.params.post_id)
                await preparePost(post_id)
                next()
            },
            component: PostZone,
            props: r => {
                const post_id = Number(r.params.post_id)
                return {post_ids: [post_id]}
            },
        }
    ],
})
