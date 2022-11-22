/* FUNCAO PARA TORNAR O MENU FIXO NA PÁGINA */
$(window).scroll(function () {
    if (450 < $(this).scrollTop()) {
        if (!$('header').hasClass('fixo'))
            $('header').addClass('fixo');
    } else {
        if ($('header').hasClass('fixo'))
            $('header').removeClass('fixo');
    }
});

/* ATIVA MENU MOBILE */
window.AtivarMenuMblExt = function () {
    var ativo = $('ul.navegar').hasClass('menuMobile');

    if (ativo)
        OcultarMenuMblExt();
    else {
        $('ul.navegar').addClass('menuMobile');
        $('#btn-ext-mobile').attr('src', 'imagens/ico-fechar.svg');
    }
}

/* OCULTA MENU MOBILE */
window.OcultarMenuMblExt = function () {
    $('ul.navegar').removeClass('menuMobile');
    $('#btn-ext-mobile').attr('src', 'imagens/ico-menu-mobile.svg');
}