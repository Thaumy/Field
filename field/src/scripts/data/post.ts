import {foldl} from "@/scripts/util/fold"
import {parsePost} from "@/scripts/type/post"
import {parseComments} from "@/scripts/type/comment"
import {CachedMixin} from "@/scripts/type/mixin"
import {
    wsRequestAllPostId,
    wsRequestPost,
    wsRequestPrevPost,
    wsRequestNextPost
} from "@/scripts/data/ws"
import {parseAdditional} from "@/scripts/type/additional"
import {notNullOrUndefined} from "@/scripts/util/nullable"

export {
    uncached_post_id,
    cached,

    prepareAllPostId,
    preparePost,

    getAllPostId,
    getPost,
    getPrevPost,
    getNextPost,
}

let uncached_post_id: number[] = []
let cached: CachedMixin[] = []

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
}

async function prepareAllPostId() {
    if (uncached_post_id.length === 0) {
        const result = await requestAllPostId()
        uncached_post_id = uncached_post_id.concat(result)
    }
    return true
}

async function preparePost(id: number) {
    const isExist = notNullOrUndefined(cached.filter(x => x.post.id === id)[0])
    if (!isExist) {
        const result = await requestPost(id)
        if (result !== null)
            cached.push(result)
        else
            return false
    }
    return true
}

function getAllPostId() {//need to prepare before call
    return uncached_post_id
}

function getPost(id: number) {//need to prepare before call
    const v = cached.filter(x => x.post.id === id)[0]

    if (notNullOrUndefined(v))
        return v
    else
        return null
}

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
