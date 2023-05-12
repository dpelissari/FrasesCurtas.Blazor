window.abreMenu = function () {
    $(".nav-container").toggleClass("is-active");
};

window.fecharMenu = function () {
    const navContainer = document.querySelector('.nav-container');
    navContainer.classList.remove('is-active');
};

window.addEventListener('click', function (event) {
    const navContainer = document.querySelector('.nav-container');
    const navItems = document.querySelector('.nav-items');
    if (navContainer.contains(event.target) || navItems.contains(event.target)) {
        return;
    }
    fecharMenu();
});

window.toggleDarkMode = function () {
    var ligth = document.getElementById("ligthmode");
    var dark = document.getElementById("darkmode");

    if (ligth.disabled) {
        ligth.disabled = false;
        dark.disabled = true;
        $('#ico-modovisual').attr('src', 'imagens/icones/ico-modo-escuro.svg');
        localStorage.setItem("modoVisual", "claro");
    } else if (dark.disabled) {
        ligth.disabled = true;
        dark.disabled = false;
        $('#ico-modovisual').attr('src', 'imagens/icones/ico-modo-claro.svg');
        localStorage.setItem("modoVisual", "escuro");
    }
}

window.onload = function () {
    var modo = localStorage.getItem("modoVisual");
    var ligth = document.getElementById("ligthmode");
    var dark = document.getElementById("darkmode");

    if (modo == "claro") {
        ligth.disabled = false;
        dark.disabled = true;
    } else if (modo == "escuro") {
        ligth.disabled = true;
        dark.disabled = false;
    }
}