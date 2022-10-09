import {
    wsRequestPostSSR,
    wsRequestAllPostIdSSR,
    wsRequestBatchPostSSR,
} from "~/scripts/data/server/ws"
import {CachedMixin} from "~/scripts/type/mixin"
import {parsePost} from "~/scripts/type/post"
import {parseComments} from "~/scripts/type/comment"
import {parseAdditional} from "~/scripts/type/additional"

export {
    requestPostSSR,
    requestBatchPostSSR,
    requestAllPostIdSSR,
}

async function requestAllPostIdSSR() {
    const response = await wsRequestAllPostIdSSR()
    if (response === '') {
        return null
    } else {
        return JSON.parse(response)
    }
}

async function requestPostSSR(id: bigint) {
    const response = await wsRequestPostSSR(id)
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

async function requestBatchPostSSR(ids: bigint[]) {
    const response = await wsRequestBatchPostSSR(ids)
    if (response === '')
        return null
    else {
        let arr = []
        for (const post of JSON.parse(response)) {
            console.log(post)
            arr.push(
                <CachedMixin>{
                    post: parsePost(post),
                    comments: parseComments(post),
                    additional: parseAdditional(post)
                })
        }

        return arr
    }
}
