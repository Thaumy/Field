import WebSocketSSR from "ws"

export {
    wsRoot,
    sendMsg,
    recvMsg,
    ApiResponse
}

const wsRoot = 'ws://localhost:8080'

type ApiResponse<T> = {
    Ok: boolean
    Msg: string
    Data: T
}

async function sendMsg(loggingHead: string, ws: WebSocketSSR, msg: string) {
    if (ws.readyState === WebSocket.OPEN) {
        ws.send(msg)
        console.log(`${loggingHead}\n${msg}`)
    } else
        setTimeout(() => {
            sendMsg(loggingHead, ws, msg)
        }, 8)
}

async function recvMsg(loggingHead: string, ws: WebSocketSSR) {
    const task = new Promise<string>(resolve => {
        let handler = (ev: MessageEvent) => {
            ws
                .off("message", handler)
            resolve(ev.data)
            console.log(`${loggingHead}\n${ev.data}`)
        }
        ws
            .on("message", handler)
    })
    return await task
}
