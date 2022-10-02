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
import {notNullOrUndefined} from "@/scripts/util/nullable";

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

                //在此处异步获取数据不甚优雅，因为还需要在组件里设置beforeUpdate
                //但是在组件的f-data里异步获取数据同样不优雅，因为这样会造成透明
                //可通过设计占位盒来优化用户体验

                //TODO title route support
                /*
                const post_id = Number(to.params.post_id)
                await preparePost(post_id)*/
                next()
            },
            component: PostZone,
            props: r => {
                //目前通过路由匹配检测+组件内请求成功与否判断404的方式并不优雅
                const post_id = Number(r.params.post_id)
                if (!isNaN(post_id))
                    return {post_ids: [post_id]}
                else
                    return {post_ids: []}
            },
        }
    ],
})
