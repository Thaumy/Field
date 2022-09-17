import {Comment} from "@/scripts/type/comment"
import {Additional} from "@/scripts/util/additional"

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
    comments: Comment[],
    additional: Additional
}

export function parsePost(responseJson: any): Post {
    const r = responseJson

    return <Post>{
        id: r['Id'],
        title: r['Title'],
        body: r['Body'],
        createTime: new Date(r['CreateTime']),
        modifyTime: new Date(r['ModifyTime'])
    }
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
