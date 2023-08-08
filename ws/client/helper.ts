import {randomId, reqStringify, respParse} from "@/ws/helper"
import {ApiRequest, ApiResponse} from "@/ws/helper"
import build_meta from "~/field.meta"

export {
    makeWebSocket,
    makeHandler
}

function makeWebSocket(api_path: string) {
    return new WebSocket(`${build_meta.wsClientRoot}${api_path}`)
}

async function makeHandler<REQ, RESP>
(api_path: string, req: REQ, conn: WebSocket) {
    if (conn.CLOSED) {
        conn = makeWebSocket(api_path)
    }
    const api_resp = request<REQ, RESP>(api_path, conn, req)
    return await api_resp
}

async function request<REQ, RESP>
(loggingHead: string, ws: WebSocket, req: REQ) {
    const api_req = {Seq: randomId(), Data: req}
    const api_resp = recvApiResp<RESP>(loggingHead, ws, api_req.Seq)
    sendApiReq(loggingHead, ws, api_req).then()
    return await api_resp
}

// @ts-ignore
let reqMq = []
let availableReq = build_meta.wsClientMaxConcurrent

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
        }, build_meta.wsClientRetryInterval)
}

async function recvApiResp<T>
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
