import {Req} from "@/ws/server/api/post/get_batch/req"
import {Rsp} from "@/ws/server/api/post/get_batch/rsp"
import WebSocketSSR from "ws"
import {makeHandler, request} from "@/ws/server/helper"
import {wsServerRoot} from "@/ws/meta"

const api_path = '/post/get_batch'

export async function handler(req: Req) {
    return makeHandler<Req, Rsp>(wsServerRoot, api_path, req)
}
