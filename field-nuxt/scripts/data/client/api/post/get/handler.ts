import {Req} from "~/scripts/data/client/api/post/get/req"
import {Rsp} from "~/scripts/data/client/api/post/get/rsp"
import {wsRoot} from "~/scripts/data/client/helper"
import {recvMsg, sendMsg} from "~/scripts/data/client/helper"
import {reqStringify, rspParse} from "~/scripts/data/helper"

const api_path = '/post/get'
const conn = new WebSocket(`${wsRoot}${api_path}`)

export async function handler(req: Req) {

    const recv = recvMsg(`${api_path} rsp:`, conn)
    const reqJson = reqStringify(req)
    sendMsg(`${api_path} req:`, conn, reqJson).then()
    const msg = await recv

    return rspParse<Rsp>(msg)
}
