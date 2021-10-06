$(document).ready(function () {
    hentSisteBillett();
})

function hentSisteBillett() {
    $.get("billett/HentAlle", function (billetter) {
        console.log(billetter);
        visBillett(billetter);
    })
        .fail(function () {
            console.log("her gikk now galt");
        })
}

function visBillett(billetter) {
    let billett = billetter.slice(-1);
    console.log("hei " + billett);
}