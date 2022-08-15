/* 函数防抖（请求触发后，在指定时间内无额外触发才允许被触发） */
export function makeDebounce
(f: () => void, delay: number) {
    let timeout_id: number | undefined = undefined;
    return () => {
        clearTimeout(timeout_id);
        timeout_id = setTimeout(() => {
            f();
        }, delay);
    };
}

