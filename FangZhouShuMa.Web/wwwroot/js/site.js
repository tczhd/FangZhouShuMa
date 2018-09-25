$(document).ready(function () {

    var removeActive = function () {
        $(".fz-navbar .nav a").parents("li, ul").removeClass("active");
    };

    $(".fz-navbar .nav li").click(function () {
        removeActive();
        $(this).addClass("active");
    });

    removeActive();
    var parent = $(".fz-navbar a[href='" + location.pathname + "']").parent("li");
    parent.addClass("active");

    var secondParent = parent.parent().parent("li");
    if (secondParent) {
        secondParent.addClass("active");
    }

});