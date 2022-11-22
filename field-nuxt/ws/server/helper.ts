import WebSocketSSR from "ws"
import {randomId, reqStringify, rspParse} from "@/ws/helper"
import {ApiRequest, ApiResponse} from "@/ws/helper"
import {wsServerRoot} from "~/ws/meta"

export {
    makeHandler
}

async function makeHandler<REQ, RSP>
(api_path: string, req: REQ) {
    const conn = new WebSocketSSR(`${wsServerRoot}${api_path}`)
    const api_rsp = await request<REQ, RSP>(api_path, conn, req)
    conn.close()
    return api_rsp
}

async function request<REQ, RSP>
(loggingHead: string, ws: WebSocketSSR, req: REQ) {
    const api_req = {Seq: randomId(), Data: req}
    const api_rsp = recvApiRsp<RSP>(loggingHead, ws, api_req.Seq)
    sendApiReq(loggingHead, ws, api_req).then()
    return await api_rsp
}

async function sendApiReq<T>
(loggingHead: string, ws: WebSocketSSR, api_req: ApiRequest<T>) {
    if (ws.readyState === WebSocketSSR.OPEN) {
        const msg = reqStringify<T>(api_req)
        ws.send(msg)
        console.log(`send ${loggingHead} req:\n${msg}`)
    } else
        setTimeout(() => {
            sendApiReq(loggingHead, ws, api_req)
        }, 8)
}

async function recvApiRsp<T>
(loggingHead: string, ws: WebSocketSSR, seq: number) {
    const task = new Promise<ApiResponse<T>>(resolve => {
        let handler = (data: WebSocketSSR.RawData) => {
            const msg = data.toString()
            const api_rsp = rspParse<T>(msg)
            if (api_rsp.Seq === seq) {
                ws
                    .off("message", handler)
                resolve(api_rsp)
                console.log(`recv ${loggingHead} rsp:\n${msg}`)
            }
        }
        ws
            .on("message", handler)
    })
    return await task
}
