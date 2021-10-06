﻿
$(document).ready(function () {

    hentAlleReiser("");

    /*
    $("#valgKiel").click(function () {
        hentAlleReiser("Kiel");
    })

    $("#valgKobenhavn").click(function () {
        hentAlleReiser("København");
    })

    $("#visAlle").click(function () {
        hentAlleReiser("");
    })
    */

    $("#reiseValg").change(function () {
        var value = $(this).val();

        if (value == "Kiel") {
            hentAlleReiser("Kiel");
        };
        if (value == "Kobenhavn") {
            hentAlleReiser("København");
        };
        if (value == "visAlle") {
            hentAlleReiser("");
        }
    }
    )
});

let valgtReise = null;


function hentAlleReiser(dest) {
    $.get("billett/hentAlleReiser", function (reiser) {
        formaterReiser(reiser, dest);
    });
}

function formaterReiser(reiser, dest) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Kjøp billett</th><th>Reiser fra</th><th>Destinasjon</th><th>Avgang</th><th>Ankomst</th>"
        "</tr>";

    if (dest == "") {
        for (let reise of reiser) {
            ut += "<tr>" +
                "<td><button id=" + reise.id + ">Kjøp her</button></td>" +
                "<td>" + reise.reiseFra + "</td>" +
                "<td>" + reise.reiseTil + "</td>" +
                "<td>" + reise.datoAvreise + ", "+ reise.tidspunktFra +"</td>" +
                "<td>" + reise.datoAnkomst + ", " + reise.tidspunktTil + "</td>" +
                "</tr>";
        }
    } else {
        for (let reise of reiser) {
            if (reise.reiseTil == dest) {
                ut += "<tr>" +
                    "<td><button id=" + reise.id + ">Kjøp her</button></td>" +
                    "<td>" + reise.reiseTil + "</td>" +
                    "<td>" + reise.reiseFra + "</td>" +
                    "<td>" + reise.tidspunktFra + "</td>" +
                    "<td>" + reise.tidspunktTil + "</td>" +
                    "</tr>";
            }
        }
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

    $.post(url, billett, function () {


        alert(billett.epost + "billetten ble lagret");
        window.location.href = 'kvittering.html';       
    })
        .fail(function () {
            console.log("Noe feil skjedde med lagringen")
        });
};