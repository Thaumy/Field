import {foldl} from "@/scripts/util/fold"
import {parsePost} from "@/scripts/type/post"
import {parseComments} from "@/scripts/type/comment"
import {PostFullData} from "@/scripts/type/post"
import {wsRequestAllPost, wsRequestPost} from "@/scripts/data/ws"
import {parseAdditional} from "@/scripts/util/additional"
import {notNullOrUndefined} from "@/scripts/util/nullable"

export let cached: PostFullData[] = []

export function isCached(post_id: number) {
    return cached.some(x => x.post.id === post_id)
}

export async function requestAllPost() {
    const response = await wsRequestAllPost()
    const responseJson = JSON.parse(response)

    return foldl(responseJson,
        (acc: PostFullData[], x: any) => {

            acc.push({
                post: parsePost(x),
                comments: parseComments(x),
                additional: parseAdditional(x)
            })
            return acc

        }, [])
}

export async function requestPost(id: number) {
    const response = await wsRequestPost(id)
    if (response === '')
        return null
    else {
        const responseJson = JSON.parse(response)

        return <PostFullData>{
            post: parsePost(responseJson),
            comments: parseComments(responseJson),
            additional: parseAdditional(responseJson)
        }
    }
}

export function getAllPostFromCache() {
    return cached
}

export function getPostFromCache(id: number) {
    const v = cached.filter(x => x.post.id === id)[0]

    if (notNullOrUndefined(v))
        return v
    else
        return null
}

export async function getAllPost() {
    //TODO
    if (cached.length !== 0)
        return cached
    else {
        const result = await requestAllPost()
        cached = cached.concat(result)
        return result
    }
}

export async function getPost(id: number) {
    const v = cached.filter(x => x.post.id === id)[0]

    if (notNullOrUndefined(v))
        return v
    else {
        const result = await requestPost(id)

        if (result === null)
            return null
        else {
            cached.push(result)
            return result
        }
    }
}

export function getPrevPost(current_post_id: number): PostFullData | null {
    const index = cached.findIndex(x => x.post.id === current_post_id)
    if (index === -1 || index - 1 < 0)
        return null
    return cached[index - 1]
}

export function getNextPost(current_post_id: number): PostFullData | null {
    const index = cached.findIndex(x => x.post.id === current_post_id)
    if (index === -1 || index + 1 > cached.length - 1)
        return null
    return cached[index + 1]
}
