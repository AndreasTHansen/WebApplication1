

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

function hentAlleReiser(dest) {
    $.get("billett/hentAlleReiser", function (reiser) {
        formaterReiser(reiser, dest);
    });
}

function formaterReiser(reiser, dest) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Kjøp billett</th><th>Reises fra</th><th>Reises til</th><th>Avgang</th><th>Ankomst</th>" +
        "</tr>";

    if (dest == "") {
        for (let reise of reiser) {
            ut += "<tr>" +
                "<td><button id=" + reise.id + ">Kjøp her</button></td>" +
                "<td>" + reise.reiseTil + "</td>" +
                "<td>" + reise.reiseFra + "</td>" +
                "<td>" + reise.tidspunktFra + "</td>" +
                "<td>" + reise.tidspunktTil + "</td>" +
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
        
        id = this.id
        HentEnReise(id)
    });
}

function velgReise(reise) {
    $("#utDestinasjon").html(reise.reiseTil);
}

function HentEnReise(tall) {
    $.get("billett/HentEnReise", { id: tall }, function (reise) {
        velgReise(reise);
    });
    
}