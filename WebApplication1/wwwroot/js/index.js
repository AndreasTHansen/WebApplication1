$(function () {
    hentAlleReiser();
});

function hentAlleReiser() {
    $.get("reise/hentAlle", function (reiser) {
        formaterReiser(reiser);
    });
}

function formaterReiser(reiser) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Reises fra</th><th>Reises til</th></th>Avgang<th></th><th>Ankomst</th><th></th><th></th>" +
        "</tr>";

    for (let reise of reiser) {
        ut += "<tr>" +
            "<td>" + reise.reiseTil + "</td>" +
            "<td>" + reise.reiseFra + "</td>" +
            "<td>" + reise.tidspunktFra + "</td>" +
            "<td>" + reise.tidspunktTil + "</td>" +
            "<td>" + kunde.poststed + "</td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#reisene").html(ut);
}