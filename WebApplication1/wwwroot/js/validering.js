function validerFornavn(fornavn) {
    const regexp = /^[a-zæøåÆØÅ\.\ \-]{2, 20}$/;
    const ok = regexp.test(fornavn);
    if (ok) {
        $("#feilFornavn").hmtl("");
        return true;
    }

    else {
        $("#feilFornavn").hmtl("Fornavnet må være mellom 2 og 20 bokstaver");
            return false;
        }
}

function validerEtteravn(etternavn) {
    const regexp = /^[a-zæøåÆØÅ\.\ \-]{2, 50}$/;
    const ok = regexp.test(etternavn);
    if (ok) {
        $("#feilEtternavn").hmtl("");
        return true;
    }

    else {
        $("#feilEtternavn").hmtl("Etternavnet må være mellom 2 og 50 bokstaver");
        return false;
    }
}

function validerEpost(epost) {
    const regexp = /^[0-9a-zæøåÆØÅ\.\ \-@/]{2, 20}$/;
    const ok = regexp.test(epost);
    if (ok) {
        $("#feilEpost").hmtl("");
        return true;
    }

    else {
        $("#feilEpost").hmtl("Fornavnet må være mellom 2 og 20 tegn");
        return false;
    }
}

function validerMobilnummer(mobilnummer) {
    const regexp = /^[0-9+]{2, 20}$/;
    const ok = regexp.test(mobilnummer);
    if (ok) {
        $("#feilMobil").hmtl("");
        return true;
    }

    else {
        $("#feilMobil").hmtl("Mobilnummeret må være mellom 8 og 10 siffer");
        return false;
    }
}
