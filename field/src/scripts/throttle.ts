/* 函数节流（触发一次，在指定时间后才能二次触发） */

/*
export function throttle(f: () => void, delay: number) {
    let prev = Date.now()
    return () => {
        const now = Date.now()
        if (now - prev >= delay) {
            f()
            prev = now
        }
    }
}
*/
export {add}

function add(x: string): string {
    return x
}