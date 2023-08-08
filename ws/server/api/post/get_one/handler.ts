import {Req} from "@/ws/server/api/post/get_one/req"
import {Resp} from "@/ws/server/api/post/get_one/resp"
import {makeHandler} from "@/ws/server/helper"

const api_path = '/post/get_one'

export let handler = async (req: Req) =>
    makeHandler<Req, Resp>(api_path, req)
