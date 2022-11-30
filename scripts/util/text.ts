export function removeHtmlTags(html: string) {
    //TODO 未经优化的正则
    return html
        .replace(/<script[^>]*>(.|\n)*?<\/script>/g, '')//脚本标签
        .replace(/<style>(.|\n)*<\/style>/g, '')//样式标签
        .replace(/<([^>]|\n)+>/g, '')//其他标签
        .replace(/&#*\w+;/g, '')//去除转义
}

export function removePunctuation(text: string) {
    //TODO 未经优化的正则
    return removeHtmlTags(text)
        .replace(/[，,。.《》（(）)！!“”‘’？?/\s\n]/g, '')//空白和常用标点去除
}
