"use strict";

(function () {
  var forms = document.querySelectorAll(".delete-form");
  var languages = {
    bg: {
      "delete": "Изтрий",
      cancel: "Отказ"
    },
    en: {
      "delete": "Delete",
      cancel: "Cancel"
    }
  };

  if (forms.length > 0) {
    forms.forEach(function (f) {
      return f.addEventListener("submit", submit);
    });
  }

  function submit(ev) {
    ev.preventDefault();
    var form = ev.target;

    if (form instanceof HTMLFormElement) {
      $("#dialog-confirm").dialog({
        resizable: false,
        height: "auto",
        width: 600,
        modal: true,
        buttons: [{
          text: languages[getCookie()]["delete"],
          click: function click() {
            $(this).dialog("close");
            form.submit();
          }
        }, {
          text: languages[getCookie()]["cancel"],
          click: function click() {
            $(this).dialog("close");
          }
        }]
      });
    }
  }

  function getCookie() {
    var cookies = document.cookie;
    var en = "en";
    var bg = "bg";
    var lang = "lang";

    if (typeof cookies === "string" && cookies.length > 0) {
      var arr = cookies.split(";");
      var current;

      for (var i = 0, length = arr.length; i < length; i += 1) {
        current = arr[i].split("=");

        if (Array.isArray(current) && current.length === 2) {
          if (current[0] === lang) {
            return (current[1] === bg || current[1] === en) && current[1] || en;
          }
        }
      }
    }

    return en;
  }
})();
