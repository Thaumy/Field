import {Req} from "@/ws/client/api/post/get_prev/req"
import {Rsp} from "@/ws/client/api/post/get_prev/rsp"
import {makeHandler, request} from "@/ws/client/helper"
import {wsClientRoot} from "@/ws/meta"

const api_path = '/post/get_next'
let conn = new WebSocket(`${wsClientRoot}${api_path}`)

export async function handler(req: Req) {
    return makeHandler<Req, Rsp>(wsClientRoot, api_path, req, conn)
}
