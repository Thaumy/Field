import {foldl} from "@/scripts/util/fold"
import {parsePost} from "@/scripts/type/post"
import {parseComments} from "@/scripts/type/comment"
import {CachedMixin} from "@/scripts/type/mixin"
import {
    wsRequestPost,
} from "@/scripts/data/client/ws"

import {parseAdditional} from "@/scripts/type/additional"
import {notNullOrUndefined} from "@/scripts/util/nullable"

export {
    preparePost,
    getPost,
}

let cacheMap = new Map<bigint, CachedMixin | null>()

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
