import {Req} from "@/ws/server/api/post/get_some/req"
import {Rsp} from "@/ws/server/api/post/get_some/rsp"
import {makeHandler} from "@/ws/server/helper"

const api_path = '/post/get_some'

export let handler = async (req: Req) =>
    makeHandler<Req, Rsp>(api_path, req)
