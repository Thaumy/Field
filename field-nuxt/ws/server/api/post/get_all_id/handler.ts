import {Req} from "@/ws/server/api/post/get_all_id/req"
import {Rsp} from "@/ws/server/api/post/get_all_id/rsp"
import WebSocketSSR from "ws"
import {request} from "@/ws/server/helper"
import {wsServerRoot} from "@/ws/meta"

const api_path = '/post/get_all_id'

export async function handler(req: Req) {
    const conn = new WebSocketSSR(`${wsServerRoot}${api_path}`)
    const api_rsp = await request<Req, Rsp>(api_path, conn, req)
    conn.close()
    return api_rsp
}