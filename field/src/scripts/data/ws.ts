import {Comment} from "@/scripts/type/comment"

export {
    wsRequestAllPostId,
    wsRequestPost,
    wsRequestPrevPost,
    wsRequestNextPost,
    wsCreateComment
}

//const wsRoot = `wss://localhost:8080`
const wsRoot = `wss://next.thaumy.cn:8080`

async function wsCreateComment(comment: Comment) {
    const ws = new WebSocket(`${wsRoot}/create_comment`)

    //TODO event remove
    ws.addEventListener('open', () => ws.send(JSON.stringify(comment)))

    const task = new Promise<string>
    (resolve =>
        ws.addEventListener("message", ev => resolve(ev.data))
    )

    const responseJson = await task
    ws.close()

    return responseJson
}

async function wsRequestAllPostId() {
    const ws = new WebSocket(`${wsRoot}/get_all_post_id`)

    //TODO event remove
    ws.addEventListener('open', () => ws.send(''))

    const task = new Promise<string>
    (resolve =>
        ws.addEventListener("message", ev => resolve(ev.data))
    )

    const responseJson = await task
    ws.close()

    return responseJson
}

async function wsRequestPost(id: number) {
    const ws = new WebSocket(`${wsRoot}/get_post`)

    //TODO event remove
    ws.addEventListener('open', () => ws.send(id.toString()))

    const task = new Promise<string>
    (resolve =>
        ws.addEventListener("message", ev => resolve(ev.data))
    )

    const responseJson = await task
    ws.close()

    return responseJson
}

async function wsRequestPrevPost(current_post_id: number) {
    const ws = new WebSocket(`${wsRoot}/get_prev_post`)

    //TODO event remove
    ws.addEventListener('open', () => ws.send(current_post_id.toString()))

    const task = new Promise<string>
    (resolve =>
        ws.addEventListener("message", ev => resolve(ev.data))
    )

    const responseJson = await task
    ws.close()

    return responseJson
}

async function wsRequestNextPost(current_post_id: number) {
    const ws = new WebSocket(`${wsRoot}/get_next_post`)

    //TODO event remove
    ws.addEventListener('open', () => ws.send(current_post_id.toString()))

    const task = new Promise<string>
    (resolve =>
        ws.addEventListener("message", ev => resolve(ev.data))
    )

    const responseJson = await task
    ws.close()

    return responseJson
}
