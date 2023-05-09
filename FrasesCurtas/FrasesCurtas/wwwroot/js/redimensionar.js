export function Escutar(dotnethelper) {
    let dimensoes = { largura: window.innerWidth, altura: window.innerHeight };

    $(window).resize(() => {

        dimensoes.largura = window.innerWidth;
        dimensoes.altura = window.innerHeight;

        dotnethelper.invokeMethodAsync('SetBrowserDimensions', dimensoes)
            .then(() => { })
            .catch(error => { console.log("Error during browser resize: " + error); });
    });

    return dimensoes;
}