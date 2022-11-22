import {Req} from "@/ws/server/api/post/get_batch/req"
import {Rsp} from "@/ws/server/api/post/get_batch/rsp"
import {makeHandler} from "@/ws/server/helper"

const api_path = '/post/get_batch'

export let handler = async (req: Req) =>
    makeHandler<Req, Rsp>(api_path, req)
