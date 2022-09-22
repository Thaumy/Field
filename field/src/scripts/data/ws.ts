export function wsRequestAllPostId() {
    const ws = new WebSocket("ws://localhost:8080/get_all_post_id")

    //TODO event remove
    ws.addEventListener('open', () => ws.send(''))

    return new Promise<string>
    ((resolve) => {
            ws.addEventListener("message", ev => {
                resolve(ev.data)
            })
        }
    ).then(responseJson => {
        ws.close()
        return responseJson
    })
}

export function wsRequestPost(id: number) {
    const ws = new WebSocket("ws://localhost:8080/get_post")

    //TODO event remove
    ws.addEventListener('open', () => ws.send(id.toString()))

    return new Promise<string>
    ((resolve) => {
            ws.addEventListener("message", ev => {
                resolve(ev.data)
            })
        }
    ).then(responseJson => {
        ws.close()
        return responseJson
    })
}

export function wsRequestPrevPost(current_post_id: number) {
    const ws = new WebSocket("ws://localhost:8080/get_prev_post")

    //TODO event remove
    ws.addEventListener('open', () => ws.send(current_post_id.toString()))

    return new Promise<string>
    ((resolve) => {
            ws.addEventListener("message", ev => {
                resolve(ev.data)
            })
        }
    ).then(responseJson => {
        ws.close()
        return responseJson
    })
}

export function wsRequestNextPost(current_post_id: number) {
    const ws = new WebSocket("ws://localhost:8080/get_next_post")

    //TODO event remove
    ws.addEventListener('open', () => ws.send(current_post_id.toString()))

    return new Promise<string>
    ((resolve) => {
            ws.addEventListener("message", ev => {
                resolve(ev.data)
            })
        }
    ).then(responseJson => {
        ws.close()
        return responseJson
    })
}
