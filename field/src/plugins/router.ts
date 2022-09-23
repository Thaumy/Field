import {
    createRouter,
    createWebHistory
} from "vue-router"
import {
    preparePost,
    prepareAllPostId,
    getPost,
    getAllPostId,
}
    from "@/scripts/data/post"
import PostZone from '@/components/common/PostZone.vue'

let frontPagePosition = 0

export default createRouter({
    scrollBehavior: (to, from, sp) => {
        if (sp)
            return sp
        if (to.path === '/' && from.path !== '/')
            return {
                top: frontPagePosition,
                behavior: 'smooth'
            }
        return {
            top: 0,
            behavior: 'smooth'
        }
    },
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
                if (from.path === '/')//保存滚动位置
                    frontPagePosition = document.documentElement.scrollTop

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
