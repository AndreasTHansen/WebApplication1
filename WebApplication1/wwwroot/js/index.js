let valgtReise = null;
var lastet = false;
var kielArr = [];
var kobenhavnArr = [];
var alleArr = [];

$(document).ready(function () {

    hentAlleReiser();

    /*
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
    */

    //Trenger litt tid på å laste inn arrayene
    //NB: Hvis vi legger til flere elementer i databasen og de slutter å vises, må vi huske å øke timeouten her

    setTimeout(function () {
        if ($("#land").text() == "Tyskland") {
            visReiser(kielArr);
        }
        if ($("#land").text() == "Danmark") {
            visReiser(kobenhavnArr);
        }
    }, 200);
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
            return;
        }
        else {
            id = this.id
            HentEnReise(id);

            //Animasjon som scroller til bunn av skjermen, kilde: 
            $('html, body').animate({
                scrollTop: $(document).height()
            },
                1000);
        }
    });

    $("#antallBarn").change(function () {
        oppdaterPris();
    });
    $("#antallVoksne").change(function () {
        oppdaterPris();
    });
}

function oppdaterPris() {
    let pris = antallVoksne.value * 100 + antallBarn.value * 50;
    $("#pris").html(pris+"kr");
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

function validerBillett() {
    const fornavnOK = validerFornavn($("#fornavn").val());
    const etternavnOK = validerEtternavn($("#etternavn").val());
    const epostOK = validerEpost($("#epost").val());
    const mobilOK = validerMobilnummer($("#mobilnummer").val());
    if (fornavnOK && etternavnOK && epostOK && mobilOK) {
        lagreBillett()
    }
}

function lagreBillett() {
    const billett = {
        fornavn: $("#fornavn").val(),
        etternavn: $("#etternavn").val(),
        epost: $("#epost").val(),
        mobilnummer: $("#mobilnummer").val(),
        antallVoksne: $("#antallVoksne").val(),
        antallBarn: $("#antallBarn").val(),
        reiseId: valgtReise.id
    };

    const url = "billett/Lagre";

    $.post(url, billett, function () {
        alert(billett.epost + "billetten ble lagret");
        window.location.href = 'kvittering.html';       
    })
        .fail(function () {
            console.log("Noe feil skjedde med lagringen")
        });
};
