import {Req} from "~/scripts/data/server/api/post/get_next/req"
import {Rsp} from "~/scripts/data/server/api/post/get_next/rsp"
import WebSocketSSR from "ws"
import {request} from "~/scripts/data/server/helper"
import {wsServerRoot} from "~/scripts/data/meta"

const api_path = '/post/get_prev'

export async function handler(req: Req) {
    const conn = new WebSocketSSR(`${wsServerRoot}${api_path}`)
    const api_rsp = await request<Req, Rsp>(api_path, conn, req)
    conn.close()
    return api_rsp
}
