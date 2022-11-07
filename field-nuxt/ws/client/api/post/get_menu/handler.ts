import {Req} from "@/ws/client/api/post/get_menu/req"
import {Rsp} from "@/ws/client/api/post/get_menu/rsp"
import {request} from "@/ws/client/helper"
import {wsClientRoot} from "@/ws/meta"

const api_path = '/post/get_menu'
let conn = new WebSocket(`${wsClientRoot}${api_path}`)

export async function handler(req: Req) {
    if (conn.CLOSED) {
        conn = new WebSocket(`${wsClientRoot}${api_path}`)
    }
    const api_rsp = request<Req, Rsp>(api_path, conn, req)
    return await api_rsp
}
