import {Comment} from "@/scripts/type/comment"

export {
    Post,
    stringifyPost
}

type Post = {
    id: bigint,
    title: string,
    body: string,
    createTime: Date,
    modifyTime: Date,
    user: string
}

function stringifyPost(post: Post) {

    function replacer(key: string, value: any) {
        if (key === "id")
            return value.toString()
        else
            return value
    }

    return JSON.stringify(post, replacer)
}

//TODO
export function parsePost(responseJson: any): Post {
    const r = responseJson

    return <Post>{
        id: BigInt(r['Id']),
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

export function getPostIn(posts: Post[], id: bigint): Post | null {
    const v = posts.filter(x => x.id === id)[0]
    if (isPost(v))
        return v
    else
        return null
}
