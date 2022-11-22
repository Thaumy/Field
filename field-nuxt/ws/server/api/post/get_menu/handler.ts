import {Req} from "@/ws/server/api/post/get_menu/req"
import {Rsp} from "@/ws/server/api/post/get_menu/rsp"
import {makeHandler} from "@/ws/server/helper"

const api_path = '/post/get_menu'

export let handler = async (req: Req) =>
    makeHandler<Req, Rsp>(api_path, req)
