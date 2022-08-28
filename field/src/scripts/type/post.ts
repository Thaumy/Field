import {Topic} from "@/scripts/type/topic";

export type Post = {
    id: number,
    title: string | null,
    body: string,
    createTime: Date,
    modifyTime: Date,
    user: string,
}
