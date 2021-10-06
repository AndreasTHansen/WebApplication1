$(document).ready(function () {
    hentSisteBillett()
})

function hentSisteBillett() {

    $.get("billett/HentAlle", function (billetter) {
        return;
    })
    
}