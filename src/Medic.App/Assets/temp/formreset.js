"use strict";

(function () {
  var form = document.querySelector('form');

  if (form) {
    form.addEventListener('reset', function (e) {
      e.preventDefault();
      e.target.querySelectorAll('input').forEach(function (i) {
        var iType = i.getAttribute('type');

        if (iType !== 'submit' && iType != 'reset' && iType !== 'hidden') {
          i.value = '';
        }
      });
      e.target.querySelectorAll('select').forEach(function (i) {
        return i.value = '';
      });
    });
  }
})();
