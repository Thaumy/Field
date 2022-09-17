function nullOrUndefined(x: any): x is null | undefined {
    return x === null || x === undefined
}

function notNullOrUndefined(x: any) {
    return !nullOrUndefined(x)
}

export {nullOrUndefined, notNullOrUndefined}
