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

export function secTimespan(big: Date, small: Date) {
    return (big.getTime() - small.getTime()) / 1000
}