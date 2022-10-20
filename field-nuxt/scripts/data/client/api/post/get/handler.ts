import {Req} from "~/scripts/data/client/api/post/get/req"
import {Rsp} from "~/scripts/data/client/api/post/get/rsp"
import {request} from "~/scripts/data/client/helper"
import {wsClientRoot} from "~/scripts/data/meta"

const api_path = '/post/get'
let conn = new WebSocket(`${wsClientRoot}${api_path}`)

export async function handler(req: Req) {
    if (conn.CLOSED) {
        conn = new WebSocket(`${wsClientRoot}${api_path}`)
    }
    const api_rsp = request<Req, Rsp>(api_path, conn, req)
    return await api_rsp
}
