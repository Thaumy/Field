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

export class PageSet {
    constructor(value: {
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
    }[]) {
        this.value = value
    }

    value
}

export class Comment {
    constructor(
        id: number,
        user: string,
        body: string,
        replyTo: number | null,
        siteUrl: string | null,
        avatarUrl: string | null,
        createTime: string,
    ) {
        this.id = id
        this.id = id
        this.user = user
        this.body = body
        this.replyTo = replyTo
        this.siteUrl = siteUrl
        this.avatarUrl = avatarUrl
        this.createTime = createTime
    }

    id
    user
    body
    replyTo
    siteUrl
    avatarUrl
    createTime
}


class CommentSet {
    constructor(comments: Comment[]) {
        this.value = comments
    }

    value
}
