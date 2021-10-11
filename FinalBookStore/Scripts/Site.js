$(document).ready(function () {
    $(".btnHide").click(function () {
        $(".jumbotron").hide(1000);
        $(this).fadeOut("slow");
        $(".btnShow").fadeIn("slow");
        $(".btnShow").show(1000);
    });
    $(".btnShow").click(function () {
        $(".jumbotron").show(1000);
        $(".btnShow").hide(1000);
        $(".btnHide").show(1000);
    });
});