function validerFornavn(fornavn) {
    const regexp = /^[a-zæøåÆØÅ\.\ \-]{2, 20}$/;
    const ok = regexp.test(fornavn);
    if (!ok) {
        $("feilFornavn").html("Fornavnet må være mellom 2 og 20 bokstaver");
        return false;
    }
    else {
    $('#feilFornavn').html("");
    return true;
    }
}

function validerEtternavn(etternavn) {
    const regexp = /^[a-zæøåÆØÅ\.\ \-]{2, 50}$/;
    const ok = regexp.test(etternavn);
    if (ok) {
        $("#feilEtternavn").html("");
        return true;
    }

    else {
        $("#feilEtternavn").html("Etternavnet må være mellom 2 og 50 bokstaver");
        return false;
    }
}

function validerEpost(epost) {
    const regexp = /^[0-9a-zæøåÆØÅ\.\ \-@/]{2, 20}$/;
    const ok = regexp.test(epost);
    if (ok) {
        $("#feilEpost").html("");
        return true;
    }

    else {
        $("#feilEpost").html("Fornavnet må være mellom 2 og 20 tegn");
        return false;
    }
}

function validerMobilnummer(mobilnummer) {
    const regexp = /^[0-9+]{2, 20}$/;
    const ok = regexp.test(mobilnummer);
    if (ok) {
        $("#feilMobil").html("");
        return true;
    }

    else {
        $("#feilMobil").html("Mobilnummeret må være mellom 8 og 10 siffer");
        return false;
    }
}
