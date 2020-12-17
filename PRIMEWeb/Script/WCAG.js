function SwitchCss(element) {
    var btnDangers = document.getElementsByClassName("btn-danger");
    var btnInfos = document.getElementsByClassName("btn-info");
    var btnInfos = document.getElementsByClassName("btn-info");
    var btnSearch = document.getElementById("btnSearch");
    var btnFilter = document.getElementById("btnFilter");
    var btnCreate = document.getElementById("btnCreate");
    var btnClear = document.getElementById("btnClear");
    var btnLogOut = document.getElementById("btnLogout");
    var btnDependents = document.getElementsByClassName("btn btn-secondary btn-dependent-page");
    var body = document.getElementsByTagName("body");
    var navigation = document.getElementsByTagName("nav");
    var ol = document.getElementsByTagName("ol");
    var container = document.getElementsByClassName("container");
    var table = document.getElementsByClassName("table");

    if (element.checked) {

        for (var i = 0; i < btnDangers.length; i++) {
            btnDangers[i].classList.add("btn-danger-high");
        }

        for (var i = 0; i < btnInfos.length; i++) {
            btnInfos[i].classList.add("btn-info-high");
        }

        for (var i = 0; i < btnDependents.length; i++) {
            btnDependents[i].classList.add("btn-dependent-high");
        }

        for (var i = 0; i < body.length; i++) {
            body[i].classList.add("body-high");
        }

        for (var i = 0; i < navigation.length; i++) {
            navigation[i].classList.add("nav-high");
        }

        for (var i = 0; i < ol.length; i++) {
            ol[i].classList.add("border-high");
        }

        for (var i = 0; i < container.length; i++) {
            container[i].classList.add("border-high");
        }

        for (var i = 0; i < table.length; i++) {
            table[i].classList.add("table-high");
        }

        btnSearch.classList.add("btn-search-high");
        btnFilter.classList.add("btn-search-high");
        btnCreate.classList.add("btn-create-high");
        btnClear.classList.add("btn-clear-high");
        btnLogOut.classList.add("btn-logout-high");
    }
    else {
        for (var i = 0; i < btnDangers.length; i++) {
            btnDangers[i].classList.remove("btn-danger-high");
        }

        for (var i = 0; i < btnInfos.length; i++) {
            btnInfos[i].classList.remove("btn-info-high");
        }

        for (var i = 0; i < btnDependents.length; i++) {
            btnDependents[i].classList.remove("btn-dependent-high");
        }

        for (var i = 0; i < body.length; i++) {
            body[i].classList.remove("body-high");
        }

        for (var i = 0; i < navigation.length; i++) {
            navigation[i].classList.remove("nav-high");
        }

        for (var i = 0; i < ol.length; i++) {
            ol[i].classList.remove("border-high");
        }

        for (var i = 0; i < container.length; i++) {
            container[i].classList.remove("border-high");
        }

        for (var i = 0; i < table.length; i++) {
            table[i].classList.remove("table-high");
        }

        btnSearch.classList.remove("btn-search-high");
        btnFilter.classList.remove("btn-search-high");
        btnCreate.classList.remove("btn-create-high");
        btnClear.classList.remove("btn-clear-high");
        btnLogOut.classList.remove("btn-logout-high");
    }
}