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
