import {ref} from "vue"
import {Tab} from "@/components/field/type"

export const about_me = ref(12387)
export const about_site = ref(12388)

export const menu_items = ref([
    <Tab><unknown>{title: '首页', route: '\/'},
    <Tab><unknown>{title: '言论', route: '\/12503'},
    <Tab><unknown>{title: '友情链接', route: '\/12383'}
    /*
    <Tab><unknown>{title: '看书', route: '\/12345'},
    <Tab><unknown>{title: '睡大觉', route: '\/12346'},
    <Tab><unknown>{title: '写代码', route: '\/12499'},
    */
])

