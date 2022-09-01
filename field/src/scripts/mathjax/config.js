window.MathJax = {
    options: {
        enableMenu: false,
        skipHtmlTags: [
            'h1', 'h2', 'h3', 'h4', 'h5', 'h6',
            'script', 'noscript', 'style',
            'textarea', 'input', 'button',
            'pre', 'code', 'kbd',
        ],
    },
    tex: {
        inlineMath: [
            ['$', '$'],
            ['\\(', '\\)']
        ],
        displayMath: [
            ['$$', '$$'],
            ['\\[', '\\]']
        ],
    }
}
