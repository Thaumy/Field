import {Post} from "@/scripts/type/post";
import {Topic} from "@/scripts/type/topic";
import {Comment} from "@/scripts/type/comment";

export type PostFullData = {
    post: Post,
    coverUrl: string | null,
    summary: string | null,
    viewCount: number,
    comments: Comment[],
    isArchive: boolean,
    isSchedule: boolean,
    prevTitle: string | null,
    nextTitle: string | null,
    topics: Topic[]
}