import {Comment, stringifyComment} from "@/scripts/type/comment"

export {
    wsRequestPost,
    wsCreateComment,
}

async function sendWhenOpen(ws: WebSocket, msg: string) {
    if (ws.readyState === WebSocket.OPEN)
        ws.send(msg)
    else
        setTimeout(() => {
            sendWhenOpen(ws, msg)
        }, 2)
}

//@ts-ignore
let ws_create_comment: WebSocket = null
//@ts-ignore
let ws_get_post: WebSocket = null

if (process.client) {
    //const wsRoot = 'wss://next.thaumy.cn:8080'
    const wsRoot = 'ws://localhost:8080'
    ws_create_comment = new WebSocket(`${wsRoot}/create_comment`)
    ws_get_post = new WebSocket(`${wsRoot}/get_post`)
} else {
    const wsRoot = 'ws://localhost:8080'
    const {WebSocket} = await import("ws")
//@ts-ignore
    ws_create_comment = new WebSocket(`${wsRoot}/create_comment`)
//@ts-ignore
    ws_get_post = new WebSocket(`${wsRoot}/get_post`)
}

async function wsCreateComment(comment: Comment) {
    const task = new Promise<string>(resolve => {
        let handler = (ev: MessageEvent) => {
            ws_create_comment
                .removeEventListener('message', handler)
            resolve(ev.data)
        }
        ws_create_comment
            .addEventListener("message", handler)
    })

    sendWhenOpen(ws_create_comment, stringifyComment(comment)).then()

    return await task
}

async function wsRequestPost(id: bigint) {
    const task = new Promise<string>(resolve => {
        let handler = (ev: MessageEvent) => {
            if (BigInt(JSON.parse(ev.data).Id) === id) {
                ws_get_post
                    .removeEventListener("message", handler)
                resolve(ev.data)
            }
        }
        ws_get_post
            .addEventListener("message", handler)
    })

    sendWhenOpen(ws_get_post, id.toString()).then()

    return await task
}
