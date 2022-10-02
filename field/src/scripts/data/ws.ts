import {Comment} from "@/scripts/type/comment"

export {
    wsRequestAllPostId,
    wsRequestPost,
    /*
    wsRequestPrevPost,
    wsRequestNextPost,
    */
    wsCreateComment
}

function sendWhenOpen(ws: WebSocket, msg: string) {
    if (ws.readyState === WebSocket.OPEN)
        ws.send(msg)
    else
        setTimeout(() => {
            sendWhenOpen(ws, msg)
        }, 2)
}

const wsRoot = `ws://localhost:8080`
//const wsRoot = `wss://next.thaumy.cn:8080`

const ws_create_comment = new WebSocket(`${wsRoot}/create_comment`)
const ws_get_all_post_id = new WebSocket(`${wsRoot}/get_all_post_id`)
const ws_get_post = new WebSocket(`${wsRoot}/get_post`)
const ws_get_prev_post = new WebSocket(`${wsRoot}/get_prev_post`)
const ws_get_next_post = new WebSocket(`${wsRoot}/get_next_post`)

async function wsCreateComment(comment: Comment) {
    sendWhenOpen(ws_create_comment, JSON.stringify(comment))

    const task = new Promise<string>(resolve => {
        let handler = (ev: MessageEvent) => {
            ws_create_comment
                .removeEventListener('message', handler)
            resolve(ev.data)
        }
        ws_create_comment
            .addEventListener("message", handler)
    })

    return await task
}

async function wsRequestAllPostId() {
    const task = new Promise<string>(resolve => {
        let handler = (ev: MessageEvent) => {
            ws_get_all_post_id
                .removeEventListener("message", handler)
            resolve(ev.data)
        }
        ws_get_all_post_id
            .addEventListener("message", handler)
    })

    sendWhenOpen(ws_get_all_post_id, '')

    return await task
}

async function wsRequestPost(id: number) {
    const task = new Promise<string>(resolve => {
        let handler = (ev: MessageEvent) => {
            if (JSON.parse(ev.data).Id === id) {
                ws_get_post
                    .removeEventListener("message", handler)
                resolve(ev.data)
            }
        }
        ws_get_post
            .addEventListener("message", handler)
    })

    sendWhenOpen(ws_get_post, id.toString())

    return await task
}

/*
async function wsRequestPrevPost(current_post_id: number) {
    ws_get_prev_post.send(current_post_id.toString())

    const task = new Promise<string>(resolve => {
        let handler = (ev: MessageEvent) => {
            ws_get_prev_post
                .removeEventListener("message", handler)
            resolve(ev.data)
        }
        ws_get_prev_post
            .addEventListener("message", handler)
    })

    return await task
}

async function wsRequestNextPost(current_post_id: number) {
    ws_get_next_post.send(current_post_id.toString())

    const task = new Promise<string>(resolve => {
        let handler = (ev: MessageEvent) => {
            ws_get_next_post
                .removeEventListener("message", handler)
            resolve(ev.data)
        }
        ws_get_next_post
            .addEventListener("message", handler)
    })

    return await task
}
*/