import {Req} from "@/ws/client/api/post/get/req"
import {Rsp} from "@/ws/client/api/post/get/rsp"
import {makeHandler, makeWebSocket} from "@/ws/client/helper"

const api_path = '/post/get'
let conn = makeWebSocket(api_path)

export let handler = async (req: Req) =>
    makeHandler<Req, Rsp>(api_path, req, conn)

