import WebSocketSSR from "ws"
import {ApiResponse} from "~/scripts/data/server/helper"

export {
    reqStringify,
    rspParse
}

function isDateKey(key: string) {
    return key.search("Time") !== -1
}

function isBigIntKey(key: string) {
    return key.search("Id") !== -1
}

function reqStringify(req: any) {
    function replacer(key: string, value: any) {
        if (isBigIntKey(key))
            return value.toString()
        if (isDateKey(key))
            return new Date(value).toISOString()

        return value
    }

    return JSON.stringify(req, replacer)
}

function rspParse<T>(rsp: string) {
    function reviver(key: string, value: any) {
        if (isBigIntKey(key))
            return BigInt(value)
        if (isDateKey(key))
            return new Date(value)

        return value
    }

    return <ApiResponse<T>>JSON.parse(rsp, reviver)
}
