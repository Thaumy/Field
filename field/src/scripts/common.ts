export function notNullThen<T>(v: T | null, f: (v: T) => void) {
    if (v)
        f(v)
}

export class ArchiveSet {
    constructor(value: {
        name: string,
    }[]) {
        this.value = value
    }

    value
}

export class TopicSet {
    constructor(value: {
        name: string,
    }[]) {
        this.value = value
    }

    value
}

export type Page = {
    id: number,
    title: string,
    summary: string,
    body: string,
    createTime: string,
    modifyTime: string,
    viewCount: number,
    commentCount: number,
    user: string,
    archives: ArchiveSet,
    topics: TopicSet
}
