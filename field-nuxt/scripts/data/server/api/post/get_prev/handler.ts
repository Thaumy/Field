import {Req} from "~/scripts/data/server/api/post/get_next/req"
import {Rsp} from "~/scripts/data/server/api/post/get_next/rsp"
import WebSocketSSR from "ws"
import {request, wsRoot} from "~/scripts/data/server/helper"

const api_path = '/post/get_prev'
const conn = new WebSocketSSR(`${wsRoot}${api_path}`)

export async function handler(req: Req) {
    const api_rsp = request<Req, Rsp>(api_path, conn, req)
    return await api_rsp
}
