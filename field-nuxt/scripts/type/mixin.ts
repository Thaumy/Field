import {Comment} from "@/scripts/type/comment"
import {Additional} from "@/scripts/type/additional"
import {Post} from "@/scripts/type/post"

export type CachedMixin = {
    post: Post,
    comments: Comment[],
    additional: Additional
}
