// Write your JavaScript code.

//=====================SIGNUP=========================

const BIRTHDAY_ERROR_MESSAGE = "La data di nascita deve essere compresa tra 100 anni fa ed oggi.";

$(".clear").click(function () {

    $(".field").val("");
    $(".radio-inline").first().prop("checked", true);
    $(".radio-inline").last().removeAttr("checked");

    bDayInput.addClass("valid");
    bDayInput.removeClass("input-validation-error");
    bDayInput.prop("aria-invalid", false);
    bDayInput.siblings("span").removeClass("field-validation-error");
    bDayInput.siblings("span").addClass("field-validation-valid");
    bDayInput.siblings("span").children("span").text("");

});

$("#Birthday").on("blur", function () {

    var bDay = new Date($("#Birthday").val());
    var today = new Date();
    var aHundredYearsAgo = new Date();
    
    aHundredYearsAgo.setFullYear(today.getFullYear() - 100, aHundredYearsAgo.getMonth(), aHundredYearsAgo.getDate());

    var bDayInput = $("#Birthday");

    if (bDay <= today &&
        bDay >= aHundredYearsAgo) {

        bDayInput.addClass("valid");
        bDayInput.removeClass("input-validation-error");
        bDayInput.prop("aria-invalid", false);
        bDayInput.siblings("span").removeClass("field-validation-error");
        bDayInput.siblings("span").addClass("field-validation-valid");
        bDayInput.siblings("span").children("span").text("");

    } else {

        bDayInput.removeClass("valid");
        bDayInput.addClass("input-validation-error");
        bDayInput.prop("aria-invalid", true);
        bDayInput.siblings("span").addClass("field-validation-error");
        bDayInput.siblings("span").removeClass("field-validation-valid");
        bDayInput.siblings("span").text(BIRTHDAY_ERROR_MESSAGE);

    }

});

$(".saveForm").submit(function () {

    if ($("#Birthday").siblings("span").text() === "") {

        return true;

    } else {

        $("#Birthday").focus();
        return false;

    }

});