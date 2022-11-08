import {Req} from "@/ws/server/api/post/get_prev/req"
import {Rsp} from "@/ws/server/api/post/get_prev/rsp"
import WebSocketSSR from "ws"
import {makeHandler, request} from "@/ws/server/helper"
import {wsServerRoot} from "@/ws/meta"

const api_path = '/post/get_next'

export async function handler(req: Req) {
    return makeHandler<Req, Rsp>(wsServerRoot, api_path, req)
}
