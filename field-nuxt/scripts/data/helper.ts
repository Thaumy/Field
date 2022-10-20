export {
    rspParse,
    randomId,
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

function randomId() {
    //TODO 考虑到palaflake会带来同步开销，此处仅提供随机Id生成，足以满足API调用确认号需要。
    return Math.floor(performance.now() * 100 + Math.random() * 100)
}

function isDateKey(key: string) {
    return key.search("Time") !== -1
}

function isBigIntKey(key: string) {
    return key.search("Id") !== -1
        || key === "Binding"
}

function isBigIntKeys(key: string) {
    return key.search("Ids") !== -1
}

function reqStringify<T>(req: ApiRequest<T>) {
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
