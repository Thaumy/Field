import {Req} from "@/ws/client/api/post/get_some/req"
import {Rsp} from "@/ws/client/api/post/get_some/rsp"
import {makeHandler, makeWebSocket} from "@/ws/client/helper"

const api_path = '/post/get_some'
let conn = makeWebSocket(api_path)

export let handler = async (req: Req) =>
    makeHandler<Req, Rsp>(api_path, req, conn)
