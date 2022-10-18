import {Req} from "~/scripts/data/client/api/post/get_all_id/req"
import {Rsp} from "~/scripts/data/client/api/post/get_all_id/rsp"
import {request} from "~/scripts/data/client/helper"
import {wsClientRoot} from "~/scripts/data/meta"

const api_path = '/post/get_all_id'
const conn = new WebSocket(`${wsClientRoot}${api_path}`)

export async function handler(req: Req) {
    const api_rsp = request<Req, Rsp>(api_path, conn, req)
    return await api_rsp
}
