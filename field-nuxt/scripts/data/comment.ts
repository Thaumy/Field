import {Comment, parseComment} from "@/scripts/type/comment"
import {wsCreateComment} from "@/scripts/data/ws"

export {createComment}

async function createComment(comment: Comment) {
    const response = await wsCreateComment(comment)
    if (response !== "")
        return parseComment(JSON.parse(response))
    else
        return null
}
