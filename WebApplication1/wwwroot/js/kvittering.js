$(document).ready(function () {
    hentSisteBillett();
})

function hentSisteBillett() {
    $.get("billett/HentAlle", function (billetter) {
        console.log(billetter);
        visBillett(billetter);
    })
        .fail(function () {
            console.log("Noe gikk galt ved henting av data");
        })
}

function visBillett(billetter) {
    let billettArr = billetter.slice(-1);
    var billett = billettArr[0];
    console.log(billett.fornavn);
}