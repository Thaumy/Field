import {Req} from "@/ws/client/api/post/get_prev/req"
import {Resp} from "@/ws/client/api/post/get_prev/resp"
import {makeHandler, makeWebSocket} from "@/ws/client/helper"

const api_path = '/post/get_next'
let conn = makeWebSocket(api_path)

export let handler = async (req: Req) =>
    makeHandler<Req, Resp>(api_path, req, conn)
