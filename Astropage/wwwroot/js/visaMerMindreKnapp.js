// https://stackoverflow.com/questions/39128483/show-more-show-less-with-jquery
// https://codepen.io/gfxahmed/pen/bGNwJdr

$(document).ready(function () {
    // dölj "visa mindre" knappen från start
    $(".up-btn").hide();

    // clickevent för "visa mindre" knapp
    $(".up-btn").click(function () {
        // dölj paragraf2
        $("#paragraf2").hide();

        // visa paragraf1
        $("#paragraf1").show();

        // p2  glider upp och göms
        $("p:not(#paragraf1)").slideUp();

        // dölj "visa mindre" knappen
        $(".up-btn").hide();

        // visa "visa mer" knappen
        $(".down-btn").show();
    });

    $(".down-btn").click(function () {

        $("#paragraf1, #paragraf2").show();

        $("p:not(#paragraf2)").slideDown();


        $(".up-btn").show();


        $(".down-btn").hide();
    });

    $("#paragraf2").hide();

});


