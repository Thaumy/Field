import {Req} from "@/ws/server/api/post/get_all_id/req"
import {Resp} from "@/ws/server/api/post/get_all_id/resp"
import {makeHandler} from "@/ws/server/helper"

const api_path = '/post/get_all_id'

export let handler = async (req: Req) =>
    makeHandler<Req, Resp>(api_path, req)
