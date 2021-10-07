function validerFornavn(fornavn) {
    const regexp = /^[a-zA-ZæøåÆØÅ -]{2,30}$/;
    console.log(fornavn);
    const ok = regexp.test(fornavn);
    if (!ok) {
        $("#feilFornavn").html("Fornavnet må være mellom 2 og 20 bokstaver");
        return false;
    }
    else {  
        $("#feilFornavn").html("");
        return true;
    }
}

function validerEtternavn(etternavn) {
    const regexp = /^[a-zA-ZæøåÆØÅ\.\ \-]{2,50}$/;
    console.log(etternavn);
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
    const regexp = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    const ok = regexp.test(epost);
    if (ok) {
        $("#feilEpost").html("");
        return true;
    }

    else {
        $("#feilEpost").html("Eposten må være mellom 2 og 30 tegn");
        return false;
    }
}

function validerMobilnummer(mobilnummer) {
    const regexp = /^[0-9\.\ \-]{8,12}$/;
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

function validerKortnummer(kortnummer) {
    const regexp = /^[0-9]{16}$/;
    const ok = regexp.test(kortnummer);
    if (ok) {
        $("#feilKort").html("");
        return true;
    }
    else {
        $("#feilKort").html("Kortnummeret må være på 16 siffer");
        return false;
    }
}

function validerCvc(cvc) {
    const regexp = /^[0-9]{3}$/;
    const ok = regexp.test(cvc);
    if (ok) {
        $("#feilCvc").html("");
        return true;
    }
    else {
        $("#feilCvc").html("cvc-en må bestå av 3 siffer");
        return false;
    }
}


function validerMåned(måned) {
    const regexp = /^(0?[1-9]|1[012])$/
    const ok = regexp.test(måned);
    if (ok) {
        $("#feilDato").html("");
        return true;
    }
    else {
        $("#feilDato").html("Måned må være en gyldig dato");
        return false;
    }
}

function validerÅr(år) {
    const regexp = /^(20)\d{2}$/;
    const ok = regexp.test(år)
    if (ok) {
        $("feilDato").html("");
        return true;
    }
    else {
        $("#feilDato").html("År må være en gyldig dato");
    }
}