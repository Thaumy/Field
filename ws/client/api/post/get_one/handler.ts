import {Req} from "@/ws/client/api/post/get_one/req"
import {Rsp} from "@/ws/client/api/post/get_one/rsp"
import {makeHandler, makeWebSocket} from "@/ws/client/helper"

const api_path = '/post/get_one'
let conn = makeWebSocket(api_path)

export let handler = async (req: Req) =>
    makeHandler<Req, Rsp>(api_path, req, conn)

