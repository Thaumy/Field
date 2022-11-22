import {Req} from "@/ws/client/api/post/get_menu/req"
import {Rsp} from "@/ws/client/api/post/get_menu/rsp"
import {makeHandler, makeWebSocket} from "@/ws/client/helper"

const api_path = '/post/get_menu'
let conn = makeWebSocket(api_path)

export let handler = async (req: Req) =>
    makeHandler<Req, Rsp>(api_path, req, conn)
