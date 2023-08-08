import {Req} from "@/ws/server/api/post/get_some/req"
import {Resp} from "@/ws/server/api/post/get_some/resp"
import {makeHandler} from "@/ws/server/helper"

const api_path = '/post/get_some'

export let handler = async (req: Req) =>
    makeHandler<Req, Resp>(api_path, req)
