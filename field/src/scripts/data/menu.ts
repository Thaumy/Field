import {ref} from "vue";
import {Post} from "@/scripts/type/post";

export const menu_posts = ref([
    <Post>{id: 12345, title: '首页'},
    <Post>{id: 12346, title: '摸摸鱼'},
    <Post>{id: 12347, title: '追番'},
    <Post>{id: 12348, title: '看书'},
    <Post>{id: 12349, title: '写代码'},
    <Post>{id: 12350, title: '睡大觉'}
])

