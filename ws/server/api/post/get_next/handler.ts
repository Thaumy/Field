import {Req} from "@/ws/server/api/post/get_prev/req"
import {Resp} from "@/ws/server/api/post/get_prev/resp"
import {makeHandler} from "@/ws/server/helper"

const api_path = '/post/get_next'

export let handler = async (req: Req) =>
    makeHandler<Req, Resp>(api_path, req)
