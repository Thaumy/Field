import {Req} from "@/ws/server/api/post/get_one/req"
import {Rsp} from "@/ws/server/api/post/get_one/rsp"
import {makeHandler} from "@/ws/server/helper"

const api_path = '/post/get_one'

export let handler = async (req: Req) =>
    makeHandler<Req, Rsp>(api_path, req)
