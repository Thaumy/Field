import {isPost} from "@/scripts/type/post";

export type Comment = {
    id: number,
    user: string,
    body: string,
    replyTo: number,
    siteUrl: string | null,
    avatarUrl: string | null,
    createTime: Date,
}

export function isComment(comment: any): comment is Comment {
    if (comment === null || comment === undefined)
        return false
    return typeof comment.replyTo === 'number'
}

export function getCommentIn(comments: Comment[], id: number): Comment | null {
    const v = comments.filter(x => x.id === id)[0]
    if (isComment(v))
        return v
    else
        return null
}
