(function (common, $, undefined) {

    common.post = (url, data, successCallBackFn) => {
        $.ajax({
            url: url,
            type: 'POST',
            dataType: 'json',
            data: data,
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
                if (response.Message && response.Message.length > 0) {
                    if (!response.IsError) {
                        common.showSuccess(response.Message);
                    } else {
                        common.showError(response.Message);
                    }
                }
                successCallBackFn(response);
            },

            error: function (jqXHR, exception) {
                if (jqXHR.status === 403) {
                    //window.location.replace("/Home/Account/NotAuthorized");
                }
                else if (jqXHR.status === 500) {
                    //showError("500: System Error");
                }
            }
        });
    }

    common.autoRedirect = (ele, seconds, url) => {
        var timer = setInterval(function () {
            seconds--;
            if (seconds === 0) {
                $("#time").html(0);
                clearInterval(timer);
                window.location.replace(url);
            } else {
                $("#"+ele).html(seconds);
            }
        }, 1000);
    }

    common.parseDate = (asp_net_mvc_date) => {
        if (asp_net_mvc_date != null) {
            return moment(asp_net_mvc_date).format("DD/MM/YYYY");
        }
        return null;
    }

    common.validateEmail = (input) => {
        var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(input);
    }

    common.activateMenu = (menuClassCss) => {
        $("." + menuClassCss).removeClass("active").addClass("active");
    }

    common.showSuccess = (msg) => {
        if ($("#divMsgNotification")) {
            $("#divMsgNotification").html(msg)
                .removeClass("quickNotification-open")
                .addClass("quickNotification-open")
                .removeClass("quickNotificationSuccess")
                .removeClass("quickNotificationError")
                .addClass("quickNotificationSuccess");
            setTimeout(() => {
                $("#divMsgNotification").html("").removeClass("quickNotification-open");
            }, 3000);
        }
        
    }

    common.showError = (msg) => {
        if ($("#divMsgNotification")) {
            $("#divMsgNotification").html(msg)
                .removeClass("quickNotification-open")
                .addClass("quickNotification-open")
                .removeClass("quickNotificationSuccess")
                .removeClass("quickNotificationError")
                .addClass("quickNotificationError");
            setTimeout(() => {
                $("#divMsgNotification").html("").removeClass("quickNotification-open");
            }, 3000);
        }
    }

})(window.common = window.common || {}, jQuery);