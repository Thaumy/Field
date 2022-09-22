export {
    wsRequestAllPostId,
    wsRequestPost,
    wsRequestPrevPost,
    wsRequestNextPost
}

async function wsRequestAllPostId() {
    const ws = new WebSocket("ws://localhost:8080/get_all_post_id")

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
    const ws = new WebSocket("ws://localhost:8080/get_post")

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
    const ws = new WebSocket("ws://localhost:8080/get_prev_post")

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
    const ws = new WebSocket("ws://localhost:8080/get_next_post")

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
