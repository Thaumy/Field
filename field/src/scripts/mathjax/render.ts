//@ts-nocheck
export async function queueTypeSet(el: HTMLElement) {
    const mathJax = window.MathJax

    if (window.mathJaxReady)
        return mathJax.typeset([el])
    else {
        mathJax.startup.promise =
            mathJax.startup.promise.then(() => {
                mathJax.typeset([el])
            })

        return Promise.resolve()
    }
}
