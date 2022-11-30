import {Req} from "@/ws/client/api/post/get_next/req"
import {Rsp} from "@/ws/client/api/post/get_next/rsp"
import {makeHandler, makeWebSocket} from "@/ws/client/helper"

const api_path = '/post/get_prev'
let conn = makeWebSocket(api_path)

export let handler = async (req: Req) =>
    makeHandler<Req, Rsp>(api_path, req, conn)
