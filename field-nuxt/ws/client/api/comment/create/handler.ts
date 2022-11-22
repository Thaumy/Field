import {Req} from "@/ws/client/api/comment/create/req"
import {Rsp} from "@/ws/client/api/comment/create/rsp"
import {makeHandler, makeWebSocket} from "@/ws/client/helper"

const api_path = '/comment/create'
let conn = makeWebSocket(api_path)

export let handler = async (req: Req) =>
    makeHandler<Req, Rsp>(api_path, req, conn)
