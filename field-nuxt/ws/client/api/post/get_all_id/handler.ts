import {Req} from "@/ws/client/api/post/get_all_id/req"
import {Rsp} from "@/ws/client/api/post/get_all_id/rsp"
import {makeHandler, makeWebSocket} from "@/ws/client/helper"

const api_path = '/post/get_all_id'
let conn = makeWebSocket(api_path)

export let handler = async (req: Req) =>
    makeHandler<Req, Rsp>(api_path, req, conn)
