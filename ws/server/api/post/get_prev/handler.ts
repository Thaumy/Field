import {Req} from "@/ws/server/api/post/get_next/req"
import {Resp} from "@/ws/server/api/post/get_next/resp"
import {makeHandler} from "@/ws/server/helper"

const api_path = '/post/get_prev'

export let handler = async (req: Req) =>
    makeHandler<Req, Resp>(api_path, req)
