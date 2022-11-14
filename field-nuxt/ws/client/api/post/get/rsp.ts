import {Rsp as Item} from "@/ws/client/api/comment/create/rsp"

export type Rsp = {
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
