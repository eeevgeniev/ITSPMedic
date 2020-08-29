(function () {
    const forms = document.querySelectorAll(".delete-form");
    const languages = {
        bg: { delete: "Изтрий", cancel: "Отказ" },
        en: { delete: "Delete", cancel: "Cancel" }
    };

    if (forms.length > 0) {
        forms.forEach(f => f.addEventListener("submit", submit));
    }

    function submit(ev) {
        ev.preventDefault();

        const form = ev.target;

        if (form instanceof HTMLFormElement) {
            $("#dialog-confirm").dialog({
                resizable: false,
                height: "auto",
                width: 600,
                modal: true,
                buttons: [
                    {
                        text: languages[getCookie()]["delete"],
                        click: function () {
                            $(this).dialog("close");
                            form.submit();
                        }
                    },
                    {
                        text: languages[getCookie()]["cancel"],
                        click: function () {
                            $(this).dialog("close");
                        }
                    }
                ]
            });
        }
    }

    function getCookie() {
        let cookies = document.cookie;
        const en = "en";
        const bg = "bg";
        const lang = "lang";

        if (typeof cookies === "string" && cookies.length > 0) {
            const arr = cookies.split(";");
            let current;

            for (let i = 0, length = arr.length; i < length; i += 1) {
                current = arr[i].split("=");

                if (Array.isArray(current) && current.length === 2) {
                    if (current[0] === lang) {
                        return ((current[1] === bg || current[1] === en) && current[1]) || en;
                    }
                }
            }
        }

        return en;
    }
})();