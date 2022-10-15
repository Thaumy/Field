import {Req} from "~/scripts/data/client/api/post/get_all_id/req"
import {Rsp} from "~/scripts/data/client/api/post/get_all_id/rsp"
import {request, wsRoot} from "~/scripts/data/client/helper"

const api_path = '/post/get_all_id'
const conn = new WebSocket(`${wsRoot}${api_path}`)

export async function handler(req: Req) {
    const api_rsp = request<Req, Rsp>(api_path, conn, req)
    return await api_rsp
}
