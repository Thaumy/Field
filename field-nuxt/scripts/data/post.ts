import {foldl} from "@/scripts/util/fold"
import {parsePost} from "@/scripts/type/post"
import {parseComments} from "@/scripts/type/comment"
import {CachedMixin} from "@/scripts/type/mixin"
import {
    wsRequestAllPostId,
    wsRequestPost,
} from "@/scripts/data/ws"

import {parseAdditional} from "@/scripts/type/additional"
import {notNullOrUndefined} from "@/scripts/util/nullable"

export {
    prepareAllPostId,
    getAllPostId,
    preparePost,
    getPost,
}

let cacheMap = new Map<bigint, CachedMixin | null>()

async function requestAllPostId() {
    const response = await wsRequestAllPostId()
    if (response === '')
        return null
    else {
        return JSON.parse(response)
    }
}

async function prepareAllPostId() {
    if (cacheMap.size < 10) {
        const ids = await requestAllPostId()
        ids.forEach((x: bigint) => {
            if (!cacheMap.has(x))
                cacheMap.set(x, null)
        })
    }
}

function getAllPostId() {
    let arr = []
    for (const x of cacheMap.keys()) {
        arr.push(x)
    }
    return arr
}

async function requestPost(id: bigint) {
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

async function preparePost(id: bigint) {
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

function getPost(id: bigint) {//need to prepare before call
    const post = cacheMap.get(id)

    if (notNullOrUndefined(post)) {
        return post
    } else
        return null
}
