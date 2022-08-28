export type Comment = {
    id: number,
    user: string,
    body: string,
    replyTo: number | null,
    siteUrl: string | null,
    avatarUrl: string | null,
    createTime: Date,
}