import {Req} from "~/scripts/data/client/api/post/get_prev/req"
import {Rsp} from "~/scripts/data/client/api/post/get_prev/rsp"
import {request} from "~/scripts/data/client/helper"
import {wsClientRoot} from "~/scripts/data/meta"

const api_path = '/post/get_next'
const conn = new WebSocket(`${wsClientRoot}${api_path}`)

export async function handler(req: Req) {
    const api_rsp = request<Req, Rsp>(api_path, conn, req)
    return await api_rsp
}
