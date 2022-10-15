import {Req} from "~/scripts/data/client/api/comment/create/req"
import {Rsp} from "~/scripts/data/client/api/comment/create/rsp"
import {wsRoot, request} from "~/scripts/data/client/helper"

const api_path = '/comment/create'
const conn = new WebSocket(`${wsRoot}${api_path}`)

export async function handler(req: Req) {
    const api_rsp = request<Req, Rsp>(api_path, conn, req)
    return await api_rsp
}
