import {Req} from "@/ws/server/api/post/get_all_id/req"
import {Rsp} from "@/ws/server/api/post/get_all_id/rsp"
import {makeHandler} from "@/ws/server/helper"

const api_path = '/post/get_all_id'

export let handler = async (req: Req) =>
    makeHandler<Req, Rsp>(api_path, req)
