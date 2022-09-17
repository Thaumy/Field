function foldl<A, X>(arr: X[], f: (acc: A, x: X) => A, acc: A): A {
    let _acc = acc

    for (const i in arr) {
        _acc = f(_acc, arr[i])
    }

    return _acc
}

function foldr<A, X>(arr: X[], f: (x: X, acc: A) => A, acc: A): A {
    let _acc = acc

    for (const i in arr) {
        _acc = f(arr[i], _acc)
    }

    return _acc
}

export {foldl, foldr}