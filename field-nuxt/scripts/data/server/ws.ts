import WebSocketSSR from "ws"

const wsRoot = 'ws://localhost:8080'
const get_all_post_id = new WebSocketSSR(`${wsRoot}/get_all_post_id`)
const get_batch_post = new WebSocketSSR(`${wsRoot}/get_batch_post`)
const get_post = new WebSocketSSR(`${wsRoot}/get_post`)

export {
    wsRequestPostSSR,
    wsRequestAllPostIdSSR,
    wsRequestBatchPostSSR,
}

async function sendWhenOpenSSR(ws: WebSocketSSR, msg: string) {
    if (ws.readyState === WebSocketSSR.OPEN)
        ws.send(msg)
    else
        setTimeout(() => {
            sendWhenOpenSSR(ws, msg)
        }, 8)
}

async function wsRequestAllPostIdSSR() {
    const task = new Promise<string>(resolve => {
        let handler = (data: any) => {
            get_all_post_id
                .off("message", handler)
            resolve(data.toString())
        }
        get_all_post_id
            .on("message", handler)
    })

    sendWhenOpenSSR(get_all_post_id, '').then()

    return await task
}

async function wsRequestPostSSR(id: bigint) {
    const task = new Promise<string>(resolve => {
        let handler = (data: any) => {
            if (BigInt(JSON.parse(data.toString()).Id) === id) {
                get_post
                    .off("message", handler)
                resolve(data.toString())
            }
        }
        get_post
            .on("message", handler)
    })

    sendWhenOpenSSR(get_post, id.toString()).then()

    return await task
}

async function wsRequestBatchPostSSR(ids: bigint[]) {

    const task = new Promise<string>(resolve => {
        let handler = (data: any) => {
            get_batch_post
                .off("message", handler)
            resolve(data.toString())
        }
        get_batch_post
            .on("message", handler)
    })

    let arr = []
    for (const id of ids)
        arr.push(id.toString())

    sendWhenOpenSSR(get_batch_post, JSON.stringify(arr)).then()

    return await task
}
