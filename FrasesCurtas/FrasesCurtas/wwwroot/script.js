/* FUNCAO PARA TORNAR O MENU FIXO NA PÁGINA */
//$(window).scroll(function () {
//    if (450 < $(this).scrollTop()) {
//        if (!$('header').hasClass('fixo'))
//            $('header').addClass('fixo');
//    } else {
//        if ($('header').hasClass('fixo'))
//            $('header').removeClass('fixo');
//    }
//});




//$(document).ready(function () {
//    const itemsMenu = document.querySelectorAll('.top-nav .parent-item');
//    itemsMenu.forEach(parentMenu => {
//        itemsMenu.addEventListener("click", toggleSubmenu);
//    })
//});


//function toggleSubmenu() {
//    this.classList.toggle('active');
//}


//window.fecharMenu = function () {
//    alert('ok');
//    var x = document.getElementById("toogle-button");
//    console.log(x);
//    x.cheched = true;
//}



//window.abreMenu = function () {
//    const nav = document.querySelector(".nav-container");

//    if (nav) {
//        if (nav.classList.contains("is-active")) {
//            nav.classList.remove("is-active");
//        } else {
//            nav.classList.add("is-active");
//        }
//    }
//};



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

