export function notNullThen<T>(v: T | null, f: (v: T) => void) {
    if (v)
        f(v)
}

export class PageSet {
    constructor(value: { id: number; title: string; }[]) {
        this.value = value
    }

    value
}
