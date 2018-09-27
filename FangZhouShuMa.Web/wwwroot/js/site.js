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

    var changeLoginPosition = function () {
        var navLoginSection = $('#navLoginSection');

        if ($(window).width() <= 767) {

            navLoginSection.removeClass('pull-right');
        }
        else {
            navLoginSection.addClass('pull-right');
        }
    };

    $(window).resize(function () {
        changeLoginPosition();
    });

    changeLoginPosition();
});