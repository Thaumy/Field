import {Req} from "@/ws/server/api/post/get_menu/req"
import {Resp} from "@/ws/server/api/post/get_menu/resp"
import {makeHandler} from "@/ws/server/helper"

const api_path = '/post/get_menu'

export let handler = async (req: Req) =>
    makeHandler<Req, Resp>(api_path, req)
