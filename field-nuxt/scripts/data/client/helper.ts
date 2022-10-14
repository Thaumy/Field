export {
    wsRoot,
    sendMsg,
    recvMsg
}

const wsRoot = 'ws://localhost:8080'

async function sendMsg(loggingHead: string, ws: WebSocket, msg: string) {
    if (ws.readyState === WebSocket.OPEN) {
        ws.send(msg)
        console.log(`${loggingHead}\n${msg}`)
    } else
        setTimeout(() => {
            sendMsg(loggingHead, ws, msg)
        }, 8)
}

async function recvMsg(loggingHead: string, ws: WebSocket) {
    const task = new Promise<string>(resolve => {
        let handler = (ev: MessageEvent) => {
            ws
                .removeEventListener("message", handler)
            resolve(ev.data)
            console.log(`${loggingHead}\n${ev.data}`)
        }
        ws
            .addEventListener("message", handler)
    })
    return await task
}
