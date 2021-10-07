hentSisteBillett();

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
    const billett = billettArr[0];

    $("#ordrenummer").html("#" + billett.id);
    $("#fornavn").html(billett.fornavn);
    $("#etternavn").html(billett.etternavn);
    $("#epost").html(billett.epost);
    $("#mobilnummer").html(billett.mobilnummer);
    $("#reiseTil").html(billett.reiseTil);
    $("#reiseFra").html(billett.reiseFra);
    $("#ankomstTid").html(billett.datoAnkomst);
    $("#avreiseTid").html(billett.datoAvreise);
    $("#totalPris").html(billett.totalPris);

    if (billett.antallVoksne > 0) {
        $("#voksenRad").css("display","table-row");
        $("#antallVoksne").html(billett.antallVoksne);
        $("#prisVoksne").html(billett.reisePris);
    }

    if (billett.antallBarn > 0) {
        $("#barnRad").css("display", "table-detail");
        $("#antallBarn").html(billett.antallBarn);
        $("#prisBarn").html(billett.reisePris / 2);
    }
}