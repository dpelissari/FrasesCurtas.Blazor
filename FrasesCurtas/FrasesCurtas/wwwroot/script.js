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
        $('#ico-modovisual').attr('src', 'imagens/ico-modo-escuro.svg');
    } else {
        ligth.disabled = true;
        dark.disabled = false;
        $('#ico-modovisual').attr('src', 'imagens/ico-modo-claro.svg');
    }
}