function validate() {
    var valoare = $('.procentaje');
    var valid = true;

    
    valoare.each(function () {
        el = $(this);
        if (el.val() < 0 || el.val() > 100 || el.val().length === 0)
            valid = false;
    });

    var s = 0;

    $('.date_colectate_grp').each(function() {
        if($(this).val().length > 0)
            s += parseFloat($(this).val());
    });


    if (valid && s < 100)
        alert('Campurile Note si Judet sub Date colecate contin date invalide!');

    s = 0;

    $('.video_grp').each(function () {
        if ($(this).val().length > 0)
            s += parseFloat($(this).val());
    });

    if (valid && s < 100)
        alert('Campurile Note Videoclip si  Videoclip Vazut sub Videoclipuri contin date invalide!');

    s = 0;

    $('.note_grp').each(function () {
        if ($(this).val().length > 0)
            s += parseFloat($(this).val());
    });

    if (valid && s < 100) {
        alert('Campurile Nota Data si  Nota Teste sub Teste contin date invalide!');
        valid = false;
    }

    s = 0;

    $('.curs_grp').each(function () {
        if ($(this).val().length > 0)
            s += parseFloat($(this).val());
    });

    if (valid && s < 100) {
        alert('Campurile Videoclipuri, Teste si Nota Curs sub Curs contin date invalide!');
        valid = false;
    }

    s = 0;

    $('.rec_grp').each(function (i) {
        if ($(this).val().length > 0)
            s += parseFloat($(this).val());
       
    });

    if (valid && s < 100) {
        
        alert('Campurile Date colectate si Curs contin date invalide!');
        valid = false;
    }
    
    
    if (!valid) alert('Date lipsa si/sau cu valori inoperabile!');
    return valid;
}