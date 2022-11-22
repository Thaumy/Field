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
<<<<<<<< HEAD:field-nuxt/ws/server/api/post/get/rsp.ts
    PrevId: bigint
    NextId: bigint
========
    /*
    PrevId: string
    NextId: string*/
>>>>>>>> dev-ssr:field-nuxt/ws/client/api/post/get/rsp.ts
    Mark: string
}
