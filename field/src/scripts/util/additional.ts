import {Topic} from "@/scripts/type/topic"

export type Additional = {
    coverUrl: string | null,
    summary: string | null,
    isGeneratedSummary: boolean,
    viewCount: number,
    disableComment: boolean,
    isArchive: boolean,
    isSchedule: boolean,
    topics: Topic[]
}

export function parseAdditional(responseJson: any) {
    const r = responseJson

    return <Additional>{
        coverUrl: r['CoverUrl'],
        summary: r['Summary'],
        isGeneratedSummary: r['IsGeneratedSummary'],
        viewCount: r['ViewCount'],
        disableComment: !r['CanComment'],
        isArchive: r['IsArchive'],
        isSchedule: r['IsSchedule'],
        topics: r['Topics'],
    }
}
