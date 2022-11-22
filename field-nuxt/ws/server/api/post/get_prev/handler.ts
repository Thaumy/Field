import {Req} from "@/ws/server/api/post/get_next/req"
import {Rsp} from "@/ws/server/api/post/get_next/rsp"
import {makeHandler} from "@/ws/server/helper"

const api_path = '/post/get_prev'

export let handler = async (req: Req) =>
    makeHandler<Req, Rsp>(api_path, req)
