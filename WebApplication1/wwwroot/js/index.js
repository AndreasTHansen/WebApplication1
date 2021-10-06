let valgtReise = null;
var kielArr = [];
var kobenhavnArr = [];
var alleArr = [];

$(document).ready(function () {

    hentAlleReiser();

    $("#reiseValg").change(function () {
        var value = $(this).val();

        if (value == "Kiel") {
            visReiser(kielArr);
        };
        if (value == "Kobenhavn") {
            visReiser(kobenhavnArr);
        };
        if (value == "visAlle") {
            visReiser(alleArr);
        }
    });
});

//Sortering av avreisedatoer
function compareDatoAvreise(a, b) {
    if (a.datoAvreise < b.datoAvreise) {
        return -1;
    }
    if (a.datoAvreise > b.datoAvreise) {
        return 1;
    }
    return 0;
}

function hentAlleReiser() {
    $.get("billett/hentAlleReiser", function (reiser) {
        init(reiser);
    });
}

function init(reiser) {
    let i = 0;
    for (let reise of reiser) {
        alleArr[i] = reise;
        i++;
    }

    alleArr.sort(compareDatoAvreise);

    kielArr = alleArr.filter(function (reise) {
        return reise.reiseTil == "Kiel";
    });
    kobenhavnArr = alleArr.filter(function (reise) {
        return reise.reiseTil == "København";
    });

    visReiser(alleArr);
}

function visReiser(reiseArr) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Kjøp billett</th><th>Reiser fra</th><th>Destinasjon</th><th>Avgang</th><th>Ankomst</th>"
    "</tr>";

    for (let i = 0; i < reiseArr.length; i++) {
        ut += "<tr>" +
            "<td><button id=" + reiseArr[i].id + ">Kjøp her</button></td>" +
            "<td>" + reiseArr[i].reiseFra + "</td>" +
            "<td>" + reiseArr[i].reiseTil + "</td>" +
            "<td>" + reiseArr[i].datoAvreise + ", " + reiseArr[i].tidspunktFra + "</td>" +
            "<td>" + reiseArr[i].datoAnkomst + ", " + reiseArr[i].tidspunktTil + "</td>"
        "</tr>";
    }

    ut += "</table>";
    $("#reisene").html(ut);

    $("button").click(function () {
        // Funksjonen skal kjøre på alle knapper utenom kjøp-knappen.
        if (this.id == "knapp") {
            lagreBillett();
            return;
        }
        else {
            id = this.id
            HentEnReise(id);
        }
    });
}


function velgReise(reise) {
    $("#kjopForm").css("display", "block");
    $("#knapp").css("display", "block");
    $("#utDestinasjon").html(reise.reiseTil);
    $("#utTid").html(reise.tidspunktFra + ", " + reise.datoAvreise)
    valgtReise = reise;
}

function HentEnReise(reiseId) {
    $.get("billett/HentEnReise", { id: reiseId }, function (reise) {
        velgReise(reise);
    });
};


function lagreBillett() {
    const billett = {
        fornavn: $("#fornavn").val(),
        etternavn: $("#etternavn").val(),
        epost: $("#epost").val(),
        mobilnummer: $("#mobilnummer").val(),
        reiseId: valgtReise.id
    };

    const url = "billett/Lagre";
    console.log(valgtReise.id)

    $.post(url, billett, function () {


        alert(billett.epost + "billetten ble lagret");
        window.location.href = 'kvittering.html';       
    })
        .fail(function () {
            console.log("Noe feil skjedde med lagringen")
        });
};
