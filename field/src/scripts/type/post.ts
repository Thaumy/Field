import {Comment} from "@/scripts/type/comment"
import {Topic} from "@/scripts/type/topic"

export type Post = {
    id: number,
    title: string,
    body: string,
    createTime: Date,
    modifyTime: Date,
    user: string
}

export type PostFullData = {
    post: Post,
    coverUrl: string | null,
    summary: string | null,
    isGeneratedSummary: boolean,
    viewCount: number,
    comments: Comment[],
    disableComment: boolean,
    isArchive: boolean,
    isSchedule: boolean,
    topics: Topic[]
}

export function isPost(post: any): post is Comment {
    if (post === null || post === undefined)
        return false
    return typeof post.title === 'string'
}

export function getPostIn(posts: Post[], id: number): Post | null {
    const v = posts.filter(x => x.id === id)[0]
    if (isPost(v))
        return v
    else
        return null
}
