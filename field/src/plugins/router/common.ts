import VueRouter from 'vue-router'

const Home = {template: '<div>Home</div>'}
const About = {template: '<div>About</div>'}

const routes = [
    {path: '/', component: Home},
    {path: '/about', component: About},
]

export default VueRouter.createRouter({
    // 4. 内部提供了 history 模式的实现。为了简单起见，我们在这里使用 hash 模式。
    history: VueRouter.createWebHashHistory(),
    routes: routes,
})
