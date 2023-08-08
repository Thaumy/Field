import {Resp as Item} from "@/ws/client/api/comment/create/resp"

export type Resp = {
    Id: string
    Title: string
    Body: string
    CreateTime: Date
    ModifyTime: Date
    CoverUrl: string
    Summary: string
    IsGeneratedSummary: boolean
    ViewCount: number
    Comments: Item[]
    CanComment: boolean
    IsArchived: boolean
    IsScheduled: boolean
    Topics: string []
    /*
    PrevId: string
    NextId: string*/
    Mark: string
}
