/* 函数节流（触发一次，在指定时间后才能二次触发） */
export function makeThrottle
(f: () => void, delay: number) {
    let prev = Date.now()
    return () => {
        const now = Date.now()
        if (now - prev >= delay) {
            f()
            prev = now
        }
    }
}