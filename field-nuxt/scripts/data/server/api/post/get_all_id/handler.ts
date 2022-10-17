import {Req} from "~/scripts/data/server/api/post/get_all_id/req"
import {Rsp} from "~/scripts/data/server/api/post/get_all_id/rsp"
import WebSocketSSR from "ws"
import {request, wsRoot} from "~/scripts/data/server/helper"

const api_path = '/post/get_all_id'

export async function handler(req: Req) {
    const conn = new WebSocketSSR(`${wsRoot}${api_path}`)
    const api_rsp = await request<Req, Rsp>(api_path, conn, req)
    conn.close()
    return api_rsp
}
