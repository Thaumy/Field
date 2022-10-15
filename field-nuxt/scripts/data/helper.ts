import WebSocketSSR from "ws"

export {
    rspParse,
    EmptyReq,
    ApiRequest,
    ApiResponse,
    reqStringify
}

type EmptyReq = {}

type ApiRequest<T> = {
    Seq: number
    Data: T
}

type ApiResponse<T> = {
    Seq: number
    Ok: boolean
    Msg: string
    Data: T
}

function isDateKey(key: string) {
    return key.search("Time") !== -1
}

function isBigIntKey(key: string) {
    return key.search("Id") !== -1
}

function isBigIntKeys(key: string) {
    return key.search("Ids") !== -1
}

function reqStringify(req: any) {
    function replacer(key: string, value: any) {
        if (isBigIntKeys(key))
            return value.map((id: any) => id.toString())
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
        if (isBigIntKeys(key))
            return value.map((id: any) => BigInt(id))
        if (isBigIntKey(key))
            return BigInt(value)
        if (isDateKey(key))
            return new Date(value)
        return value
    }

    return <ApiResponse<T>>JSON.parse(rsp, reviver)
}
