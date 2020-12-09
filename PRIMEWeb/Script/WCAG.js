function SwitchCss(element) {
    var btnDangers = document.getElementsByClassName("btn-danger");
    var btnInfos = document.getElementsByClassName("btn-info");
    var btnInfos = document.getElementsByClassName("btn-info");
    var btnSearch = document.getElementById("btnSearch");
    var btnFilter = document.getElementById("btnFilter");
    var btnCreate = document.getElementById("btnCreate");
    var btnClear = document.getElementById("btnClear");

    if (element.checked) {

        for (var i = 0; i < btnDangers.length; i++) {
            btnDangers[i].classList.add("btn-danger-high");
        }

        for (var i = 0; i < btnInfos.length; i++) {
            btnInfos[i].classList.add("btn-info-high");
        }

        btnSearch.classList.add("btn-search-high");
        btnFilter.classList.add("btn-search-high");
        btnCreate.classList.add("btn-create-high");
        btnClear.classList.add("btn-clear-high");
    }
    else {
        for (var i = 0; i < btnDangers.length; i++) {
            btnDangers[i].classList.remove("btn-danger-high");
        }

        for (var i = 0; i < btnInfos.length; i++) {
            btnInfos[i].classList.remove("btn-info-high");
        }

        btnSearch.classList.remove("btn-search-high");
        btnFilter.classList.remove("btn-search-high");
        btnCreate.classList.remove("btn-create-high");
        btnClear.classList.remove("btn-clear-high");
    }
}