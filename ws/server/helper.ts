import WebSocketSSR from "ws"
import {randomId, reqStringify, respParse} from "@/ws/helper"
import {ApiRequest, ApiResponse} from "@/ws/helper"
import build_meta from "~/field.meta"

export {
    makeHandler
}

async function makeHandler<REQ, RESP>
(api_path: string, req: REQ) {
    const conn = new WebSocketSSR(`${build_meta.wsServerRoot}${api_path}`)
    const api_rsp = await request<REQ, RSP>(api_path, conn, req)
    conn.close()
    return api_resp
}

async function request<REQ, RESP>
(loggingHead: string, ws: WebSocketSSR, req: REQ) {
    const api_req = {Seq: randomId(), Data: req}
    const api_resp = recvApiResp<RESP>(loggingHead, ws, api_req.Seq)
    sendApiReq(loggingHead, ws, api_req).then()
    return await api_resp
}

async function sendApiReq<T>
(loggingHead: string, ws: WebSocketSSR, api_req: ApiRequest<T>) {
    if (ws.readyState === WebSocketSSR.OPEN) {
        const msg = reqStringify<T>(api_req)
        ws.send(msg)

        if (build_meta.enableServerDevLog)
            console.log(`send ${loggingHead} req:\n${msg}`)
    } else
        setTimeout(() => {
            sendApiReq(loggingHead, ws, api_req)
        }, 8)
}

async function recvApiResp<T>
(loggingHead: string, ws: WebSocketSSR, seq: number) {
    const task = new Promise<ApiResponse<T>>(resolve => {
        let handler = (data: WebSocketSSR.RawData) => {
            const msg = data.toString()
            const api_rsp = rspParse<T>(msg)
            if (api_rsp.Seq === seq) {
                ws.off("message", handler)
                resolve(api_rsp)

                if (build_meta.enableServerDevLog)
                    console.log(`recv ${loggingHead} rsp:\n${msg}`)
            }
        }
        ws
            .on("message", handler)
    })
    return await task
}
