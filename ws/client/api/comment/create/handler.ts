import {Req} from "@/ws/client/api/comment/create/req"
import {Resp} from "@/ws/client/api/comment/create/resp"
import {makeHandler, makeWebSocket} from "@/ws/client/helper"

const api_path = '/comment/create'
let conn = makeWebSocket(api_path)

export let handler = async (req: Req) =>
    makeHandler<Req, Resp>(api_path, req, conn)
