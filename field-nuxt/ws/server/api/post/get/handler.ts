import {Req} from "@/ws/server/api/post/get/req"
import {Rsp} from "@/ws/server/api/post/get/rsp"
import {makeHandler} from "@/ws/server/helper"

const api_path = '/post/get'

export let handler = async (req: Req) =>
    makeHandler<Req, Rsp>(api_path, req)
