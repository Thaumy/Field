export function formatToDate(d: Date) {
    return d.getFullYear().toString().substring(2) + '-' +
        (d.getMonth() + 1) + '-' +
        d.getDate()
}

export function formatToDateTime(d: Date) {
    return d.getFullYear().toString().substring(2) + '-' +
        (d.getMonth() + 1) + '-' +
        d.getDate() + ' ' +
        d.getHours() + ':' +
        d.getMinutes()
}
