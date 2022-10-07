import {foldl} from "@/scripts/util/fold"

export {
    Comment,
    stringifyComment
}

type Comment = {
    id: bigint,
    user: string,
    body: string,
    binding: bigint,
    isReply: boolean,
    siteUrl: string | null,
    avatarUrl: string | null,
    createTime: Date,
}

function stringifyComment(comment: Comment) {

    function replacer(key, value) {
        if (key === "id" || key === "binding")
            return value.toString()
        else
            return value
    }

    return JSON.stringify(comment, replacer)
}

//TODO
export function parseComment(responseJson: any): Comment {
    const r = responseJson

    return <Comment>{
        id: BigInt(r["Id"]),
        user: r["User"],
        body: r["Body"],
        binding: BigInt(r["Binding"]),
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
    return typeof comment.binding === 'bigint'
}

export function getCommentIn(comments: Comment[], id: bigint): Comment | null {
    const v = comments.filter(x => x.id === id)[0]
    if (isComment(v))
        return v
    else
        return null
}
