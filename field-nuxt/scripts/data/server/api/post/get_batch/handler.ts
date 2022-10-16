import {Req} from "~/scripts/data/server/api/post/get_batch/req"
import {Rsp} from "~/scripts/data/server/api/post/get_batch/rsp"
import WebSocketSSR from "ws"
import {request, wsRoot} from "~/scripts/data/server/helper"

const api_path = '/post/get_batch'

export async function handler(req: Req) {
    const conn = new WebSocketSSR(`${wsRoot}${api_path}`)
    const api_rsp = request<Req, Rsp>(api_path, conn, req)
    conn.close()
    return await api_rsp
}
