const LineChart = (function () {
    return function (elementTarget, data, options) {
        if (!(elementTarget instanceof Element) || elementTarget.nodeName !== 'CANVAS') {
            throw new Error(`${elementTarget} is not element or it's not canvas element.`)
        }

        return new Chart(elementTarget, { type: 'line', data: data, options: options });
    }
})();