$(function banane() {
    var isValid = false;
    var valoare = $('.procentaje');
    var submit = $('.buaton');

    valoare.on('change', function (e) {
        //alert(e.target.value);
        e.preventDefault();
    });
    
    console.log(submit);
    submit.on("change", function (e) {
        alert('got here');
            e.preventDefault();
    });
});