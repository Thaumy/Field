import {Topic} from "@/scripts/type/topic"
import {Comment} from "~/scripts/type/comment";

export {
    Additional,
    stringifyAdditional
}

type Additional = {
    coverUrl: string | null,
    summary: string | null,
    isGeneratedSummary: boolean,
    viewCount: number,
    disableComment: boolean,
    isArchived: boolean,
    isScheduled: boolean,
    topics: Topic[],
    prevId: bigint | null,
    nextId: bigint | null
}

function stringifyAdditional(additional: Additional) {

    function replacer(key, value) {
        if (key === "prevId" || key === "nextId")
            return value.toString()
        else
            return value
    }

    return JSON.stringify(additional, replacer)
}

//TODO
export function parseAdditional(responseJson: any) {
    const r = responseJson

    return <Additional>{
        coverUrl: r['CoverUrl'],
        summary: r['Summary'],
        isGeneratedSummary: r['IsGeneratedSummary'],
        viewCount: r['ViewCount'],
        disableComment: !r['CanComment'],
        isArchived: r['IsArchived'],
        isScheduled: r['IsScheduled'],
        topics: r['Topics'],
        prevId: BigInt(r['PrevId']) < 0n ? null : BigInt(r['PrevId']),
        nextId: BigInt(r['NextId']) < 0n ? null : BigInt(r['NextId'])
    }
}
