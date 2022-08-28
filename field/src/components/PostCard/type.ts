import {Post} from "@/scripts/type/post";
import {Topic} from "@/scripts/type/topic";

export type PostCardData = {
    post: Post,
    coverUrl: string | null,
    summary: string | null,
    viewCount: number,
    commentCount: number,
    isArchive: boolean,
    isSchedule: boolean,
    prevTitle: string | null,
    nextTitle: string | null,
    topics: Topic[]
}