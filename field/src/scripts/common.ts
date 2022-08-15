export function notNullThen<T>(v: T | null, f: (v: T) => void) {
    if (v)
        f(v)
}
