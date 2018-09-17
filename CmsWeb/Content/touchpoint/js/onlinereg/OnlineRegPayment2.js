﻿function noBack() { window.history.forward(); }
$(function () {
    noBack();
    $("div.date input").datepicker({
        autoclose: true,
        orientation: "auto",
        forceParse: false,
        format: $.dtoptions.format
    });
    $("#applydonation").click(function (ev) {
        ev.preventDefault();
        return false;
    });
    $("#formerror").hide();
    $("a.submitbutton, a.submitlink").click(function (ev) {
        ev.preventDefault();
        if (!agreeterms) {
            alert("must agree to terms");
            return false;
        }
        var f = $(this).closest('form');
        var href = this.href;
        var q = f.serialize();
        $.blockUI();
        $.post(href, q, function (ret) {
            $.unblockUI();
            if (ret.error) {
                $("#formerror").show();
                $('#errormessage').text(ret.error);
            } else if (ret.amtdue && ret.amtdue > 0) {
                $("#formerror").hide();
                $('#amt').text(ret.amt);
                $('#AmtToPay').val(ret.tiamt);
                $('#Amtdue').val(ret.amtdue);
                $('#Coupon').val('');
                $("#form-msg").show();
                $('#coupon-msg').html(ret.msg);
                $('#ApplyCoupon').hide();
            } else {
                var form = $('#success_form');
                form.attr("action", ret.confirm);
                form.submit();
            }
        });
        return false;
    });
	$('.clearField').each(function () {
        if ($(this).val() == '') {
            $(this).val($(this).attr('default'));
            $(this).addClass('text-label');
        }
	    $(this).focus(function () {
	        if (this.value == $(this).attr('default')) {
	            this.value = '';
	            $(this).removeClass('text-label');
	        }
	    });
	    $(this).blur(function () {
	        if (this.value == '') {
	            this.value = $(this).attr('default');
	            $(this).addClass('text-label');
	        }
	    });
	});
    $('#Coupon').showPassword();

    $('#findidclick').click(function (ev) {
        ev.preventDefault();
        $("#findid").show();
        return false;
    });
    $('#findacctclick').click(function (ev) {
        ev.preventDefault();
        $("#findacct").show();
        return false;
    });
    var agreeterms = true;
    $("form").submit(function () {
        if (!agreeterms) {
            alert("must agree to terms");
            return false;
        }
        if (!$("#submitit").val())
            return false;
        if ($("form").valid()) {
            $("#submitit").attr("disabled", "disabled");
            return true;
        }
        return false;
    });

    if ($('#IAgree').attr("id")) {
        $(".showform").hide();
        agreeterms = false;
    }
    $("#IAgree").click(function () {
        var checked_status = this.checked;
        if (checked_status == true) {
            $(".showform").show();
            $("#Terms").hide();
            agreeterms = true;
        } else {
            $(".showform").hide();
            $("#Terms").show();
            agreeterms = false;
        }
    });
    $.SetSummaryText = function () {
        var pattern = $("#RepeatPattern").val();
        var everyN = $("#EveryN").val();
        var day1 = $("#Day1").val();
        var day2 = $("#Day2").val();
        var startOn = $("#StartWhen").val();

        var summary = "";
        if (pattern === "S") {
            if (day1.length > 0 && day2.length > 0)
                summary = "Twice a month on day " + day1 + " and day " + day2;
        } else {
            var patternText = "";
            if (pattern === "M") {
                patternText = "month";
            } else {
                patternText = "week";
            }
            if (everyN > 1) {
                summary = "Every " + everyN + " " + patternText + "s";
            } else {
                summary = "Every " + everyN + " " + patternText;
            }
        }
        if (startOn && startOn.length > 0)
            summary += " starting on or after " + startOn;
        $("#SummaryText").text(summary);
    };
   
    $.ShowPaymentInfo = function (v) {
        $(".Card").hide();
        $(".Bank").hide();
        if (v === 'C')
            $(".Card").show();
        else if (v === 'B') {
            $(".Bank").show();
            CancelCreditCardInfoUpdate();
        }
    };
    $.SetRepeatPatternText = function(v) {
        if (v === 'M') {
            $("#RepeatPatternText").text(" month(s)");
        }
        else
            $("#RepeatPatternText").text(" week(s)");
    };
    $.ShowPeriodInfo = function (v) {
        $(".everyPeriod").hide();
        $(".twiceMonthly").hide();
        if (v === 'S')
            $(".twiceMonthly").show();
        else {
            $(".everyPeriod").show();
            $.SetRepeatPatternText(v);
            $("#Period").val(v);
        }
    };
    $.SetSemiEvery = function(v) {
        if (v != 'S') {
            $("#SemiEvery").val('E');
        } else {
            $("#SemiEvery").val('S');
        }
    };
    $("body").on("change", 'input[name=Type]', function () {
        var v = $("input[name=Type]:checked").val();
        $.ShowPaymentInfo(v);
    });
    $("body").on("change", 'select[name=RepeatPattern]', function () {
        var v = $("select[name=RepeatPattern]").val();
        $.SetSemiEvery(v);
        $.ShowPeriodInfo(v);
        $.SetSummaryText();
    });
    $("body").on("change", 'select[name=EveryN]', function () {
        $.SetSummaryText();
    });
    $("body").on("change", 'input[name=Day1]', function () {
        $.SetSummaryText();
    });
    $("body").on("change", 'input[name=Day2]', function () {
        $.SetSummaryText();
    });
    $("body").on("change", 'input[name=StartWhen]', function () {
        $.SetSummaryText();
    });

    if ($('#CreditCard').length) {
        if ($('#CreditCard').val().startsWith('X')) {
            $('#CVV').parents('.form-group').hide();
            $('#CancelUpdateText').parents('.form-group').hide();
        }
        $('#CreditCard').change(function () {
            $('#CVV').parents('.form-group').show();
            if ($('#CreditCard').val().startsWith('X')) {
                $('#CreditCard').val($('#CreditCard').val().replace('X', 'Y'));
            }
            $('#CancelUpdateText').parents('.form-group').show();
        });
        $('#Expires').change(function () {
            if ($('#CreditCard').val().startsWith('X')) {
                $('#CreditCard').val($('#CreditCard').val().replace('X', 'Y'));
            }
            $('#CVV').parents('.form-group').show();
            $('#CancelUpdateText').parents('.form-group').show();
        });
        $('#CancelUpdateText').click(function () {
            CancelCreditCardInfoUpdate();
        });
    }

    function CancelCreditCardInfoUpdate() {
        //Getting CC number and Expire date from what is saved in DB
        var sessionCConFile = $("#hdnCreditCardOnFile").data('value');
        var sessionExiresonFile = $("#hdnExpiresOnFile").data('value');
        $('#CreditCard').val(sessionCConFile);
        $('#Expires').val(sessionExiresonFile);
        //Setting CVV to empty and hiding CVV and Cancel Update btn.
        $('#CVV').val('');
        $('#CVV').parents('.form-group').hide();
        $('#CancelUpdateText').parents('.form-group').hide();
        $('#Expires').focus();
        //Removes validation summary
        $('.validation-summary-errors').empty();
        $('.validation-summary-errors').addClass('validation-summary-valid');
        $('.validation-summary-errors').removeClass('validation-summary-errors');
        //Removes validation message after input-fields
        $(".field-validation-error").empty();
        $(".input-validation-error").removeClass("input-validation-error");

        $(".state-error").removeClass("state-error");
        $(".state-success").removeClass("state-success");
        $(this).trigger('reset.unobtrusiveValidation');
    }
    
    if ($("#allowcc").val()) {
        $.ShowPaymentInfo($("input[name=Type]:checked").val());
    }
    var repeatPattern = $("select[name=RepeatPattern]").val();
    $.SetSemiEvery(repeatPattern);
    $.ShowPeriodInfo(repeatPattern);
    $.SetSummaryText();
    $.validator.setDefaults({
        highlight: function (input) {
            $(input).addClass("input-validation-error");
        },
        unhighlight: function (input) {
            $(input).removeClass("input-validation-error");
        }
    });
    // validate signup form on keyup and submit
    $("form").validate({
        rules: {
            "First": { required: true, maxlength: 50 },
            "MiddleInitial": { maxlength: 1},
            "Last": { required: true, maxlength: 50 },
            "Suffix": { maxlength: 10 },
            "Phone": { maxlength: 50 }
        },
        errorPlacement: function(error, element) {
            if (element.hasClass("clearField")) {
                $("#errorName").append(error);
            }
            else {
                error.insertAfter(element);
            }
        },
        errorClass: "field-validation-error"
    });

});

