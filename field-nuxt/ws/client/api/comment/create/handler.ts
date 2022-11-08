import {Req} from "@/ws/client/api/comment/create/req"
import {Rsp} from "@/ws/client/api/comment/create/rsp"
import {makeHandler, request} from "@/ws/client/helper"
import {wsClientRoot} from "@/ws/meta"

const api_path = '/comment/create'
let conn = new WebSocket(`${wsClientRoot}${api_path}`)

export async function handler(req: Req) {
    return makeHandler<Req, Rsp>(wsClientRoot, api_path, req, conn)
}
