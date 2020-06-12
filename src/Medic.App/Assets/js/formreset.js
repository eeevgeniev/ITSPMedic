(function () {
    var form = document.querySelector('form');

    if (form) {
        form.addEventListener('reset', (e) => {
            e.preventDefault();

            e.target.querySelectorAll('input').forEach(i => {
                const iType = i.getAttribute('type');

                if (iType !== 'submit' && iType != 'reset' && iType !== 'hidden') {
                    i.value = '';
                }
            });

            e.target.querySelectorAll('select').forEach(i => i.value = '');
        });
    }
})();