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
    let billettArr = billetter.slice(-1);
    const billett = billettArr[0];

    $("#ordrenummer").html("#" + billett.id);
    $("#fornavn").html(billett.fornavn);
    $("#etternavn").html(billett.etternavn);
    $("#epost").html(billett.fornavn);
    $("#mobilnummer").html(billett.mobilnummer);
    $("#reiseTil").html(billett.reiseTil);
    $("#reiseFra").html(billett.reiseFra);
    $("#ankomstTid").html(billett.datoAnkomst);
    $("#avreiseTid").html(billett.datoAvreise);
}