import {Req} from "@/ws/server/api/post/get_menu/req"
import {Rsp} from "@/ws/server/api/post/get_menu/rsp"
import WebSocketSSR from "ws"
import {makeHandler, request} from "@/ws/server/helper"
import {wsServerRoot} from "@/ws/meta"

const api_path = '/post/get_menu'

export async function handler(req: Req) {
    return makeHandler<Req, Rsp>(wsServerRoot, api_path, req)
}
