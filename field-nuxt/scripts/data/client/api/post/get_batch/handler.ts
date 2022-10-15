import {Req} from "~/scripts/data/client/api/post/get_batch/req"
import {Rsp} from "~/scripts/data/client/api/post/get_batch/rsp"
import {request, wsRoot} from "~/scripts/data/client/helper"

const api_path = '/post/get_batch'
const conn = new WebSocket(`${wsRoot}${api_path}`)

export async function handler(req: Req) {
    const api_rsp = request<Req, Rsp>(api_path, conn, req)
    return await api_rsp
}
