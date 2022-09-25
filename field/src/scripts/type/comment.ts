import {foldl} from "@/scripts/util/fold"

export type Comment = {
    id: number,
    user: string,
    body: string,
    binding: number,
    isReply: boolean,
    siteUrl: string | null,
    avatarUrl: string | null,
    createTime: Date,
}

export function parseComment(responseJson: any): Comment {
    const r = responseJson

    return <Comment>{
        id: r["Id"],
        user: r["User"],
        body: r["Body"],
        binding: r["Binding"],
        isReply: r["IsReply"],
        siteUrl: r["SiteUrl"],
        avatarUrl: r["AvatarUrl"],
        createTime: new Date(r["CreateTime"])
    }
}

export function parseComments(responseJson: any): Comment[] {
    return foldl(responseJson['Comments'],
        (acc: Comment[], x: any) => {
            acc.push(parseComment(x))
            return acc
        }, [])
}

export function isComment(comment: any): comment is Comment {
    if (comment === null || comment === undefined)
        return false
    return typeof comment.binding === 'number'
}

export function getCommentIn(comments: Comment[], id: number): Comment | null {
    const v = comments.filter(x => x.id === id)[0]
    if (isComment(v))
        return v
    else
        return null
}
