import {Req} from "@/ws/server/api/post/get_prev/req"
import {Rsp} from "@/ws/server/api/post/get_prev/rsp"
import {makeHandler} from "@/ws/server/helper"

const api_path = '/post/get_next'

export let handler = async (req: Req) =>
    makeHandler<Req, Rsp>(api_path, req)
