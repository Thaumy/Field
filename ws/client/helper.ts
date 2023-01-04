import {randomId, reqStringify, rspParse} from "@/ws/helper"
import {ApiRequest, ApiResponse} from "@/ws/helper"
import build_meta from "~/field.meta"

export {
    makeWebSocket,
    makeHandler
}

function makeWebSocket(api_path: string) {
    return new WebSocket(`${build_meta.wsClientRoot}${api_path}`)
}

async function makeHandler<REQ, RSP>
(api_path: string, req: REQ, conn: WebSocket) {
    if (conn.CLOSED) {
        conn = makeWebSocket(api_path)
    }
    const api_rsp = request<REQ, RSP>(api_path, conn, req)
    return await api_rsp
}

async function request<REQ, RSP>
(loggingHead: string, ws: WebSocket, req: REQ) {
    const api_req = {Seq: randomId(), Data: req}
    const api_rsp = recvApiRsp<RSP>(loggingHead, ws, api_req.Seq)
    sendApiReq(loggingHead, ws, api_req).then()
    return await api_rsp
}

async function sendApiReq<T>
(loggingHead: string, ws: WebSocket, api_req: ApiRequest<T>) {
    if (ws.readyState === WebSocket.OPEN) {
        const msg = reqStringify<T>(api_req)
        ws.send(msg)

        if (build_meta.enableClientDevLog)
            console.log(`send ${loggingHead} req:\n${msg}`)
    } else
        setTimeout(() => {
            sendApiReq(loggingHead, ws, api_req)
        }, 8)
}

async function recvApiRsp<T>
(loggingHead: string, ws: WebSocket, seq: number) {
    const task = new Promise<ApiResponse<T>>(resolve => {
        let handler = (ev: MessageEvent) => {
            const msg = ev.data
            const api_rsp = rspParse<T>(msg)
            if (api_rsp.Seq === seq) {
                ws.removeEventListener("message", handler)
                resolve(api_rsp)

                if (build_meta.enableClientDevLog)
                    console.log(`recv ${loggingHead} rsp:\n${msg}`)
            }
        }
        ws
            .addEventListener("message", handler)
    })
    return await task
}
