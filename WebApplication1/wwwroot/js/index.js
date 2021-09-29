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
        "<th>Reise-id</th><th>Reises fra</th><th>Reises til</th><th>Avgang</th><th>Ankomst</th>" +
        "</tr>";

    for (let reise of reiser) {
        ut += "<tr>" +
            "<td>" + reise.id + "</td>" +
            "<td>" + reise.reiseTil + "</td>" +
            "<td>" + reise.reiseFra + "</td>" +
            "<td>" + reise.tidspunktFra + "</td>" +
            "<td>" + reise.tidspunktTil + "</td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#reisene").html(ut);
}