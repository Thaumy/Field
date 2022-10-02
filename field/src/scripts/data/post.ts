import {foldl} from "@/scripts/util/fold"
import {parsePost} from "@/scripts/type/post"
import {parseComments} from "@/scripts/type/comment"
import {CachedMixin} from "@/scripts/type/mixin"
import {
    wsRequestAllPostId,
    wsRequestPost,
    /*
    wsRequestPrevPost,
    wsRequestNextPost
     */
} from "@/scripts/data/ws"
import {parseAdditional} from "@/scripts/type/additional"
import {notNullOrUndefined} from "@/scripts/util/nullable"

export {
    prepareAllPostId,
    preparePost,

    getAllPostId,
    getPost,
}

let cacheMap = new Map<number, CachedMixin | null>()

async function requestAllPostId() {
    const response = await wsRequestAllPostId()
    const responseJson = JSON.parse(response)

    return foldl(responseJson,
        (acc: number[], x: any) => {

            acc.push(x)
            return acc

        }, [])
}

async function requestPost(id: number) {
    const response = await wsRequestPost(id)
    if (response === '')
        return null
    else {
        const responseJson = JSON.parse(response)

        return <CachedMixin>{
            post: parsePost(responseJson),
            comments: parseComments(responseJson),
            additional: parseAdditional(responseJson)
        }
    }
}

/*
async function requestPrevPost(current_post_id: number) {
    const response = await wsRequestPrevPost(current_post_id)
    if (response === '')
        return null
    else {
        const responseJson = JSON.parse(response)

        return <CachedMixin>{
            post: parsePost(responseJson),
            comments: parseComments(responseJson),
            additional: parseAdditional(responseJson)
        }
    }
}

async function requestNextPost(current_post_id: number) {
    const response = await wsRequestNextPost(current_post_id)
    if (response === '')
        return null
    else {
        const responseJson = JSON.parse(response)

        return <CachedMixin>{
            post: parsePost(responseJson),
            comments: parseComments(responseJson),
            additional: parseAdditional(responseJson)
        }
    }
}*/

async function prepareAllPostId() {
    if (cacheMap.size === 0) {
        const post_ids = await requestAllPostId()
        post_ids.forEach(id => cacheMap.set(id, null))
    }
}

async function preparePost(id: number) {
    const post = cacheMap.get(id)
    if (notNullOrUndefined(post)) {
        return true
    } else {
        const result = await requestPost(id)
        if (result !== null) {
            cacheMap.set(id, result)
            return true
        } else
            return false
    }
}

function getAllPostId() {//need to prepare before call
    //TODO cachedMap有待优化，目前的实现和用例相当低效
    let arr: number[] = []

    for (const x of cacheMap.keys())
        arr.push(x)

    return arr
}

function getPost(id: number) {//need to prepare before call
    const post = cacheMap.get(id)

    if (notNullOrUndefined(post)) {
        return post
    } else
        return null
}

/*
function getPrevPost(current_post_id: number): CachedMixin | null {
    const index = cached.findIndex(x => x.post.id === current_post_id)
    if (index === -1 || index - 1 < 0)
        return null
    return cached[index - 1]
}

function getNextPost(current_post_id: number): CachedMixin | null {
    const index = cached.findIndex(x => x.post.id === current_post_id)
    if (index === -1 || index + 1 > cached.length - 1)
        return null
    return cached[index + 1]
}
*/