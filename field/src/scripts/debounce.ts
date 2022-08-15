/* 函数防抖（请求触发后，在指定时间内无额外触发才允许被触发） */
export function debounce(fn, delay) {
    let timeout = null;
    return function (e) {
        clearTimeout(timeout);
        timeout = setTimeout(() => {
            fn.apply(this, arguments);
        }, delay);
    };
}

