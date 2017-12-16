(function (notification, $, ko, undefined) {

    var self = this;

    class EmailSetting {
        constructor(email) {
            this.EnablePush = ko.observable(email.EnablePush);
            this.EnableNewAssignedAction = ko.observable(email.EnableNewAssignedAction);
            this.EnableSelfCreatedActionComplete = ko.observable(email.EnableSelfCreatedActionComplete);
            this.EnableAnswerInAuditTriggerNotification = ko.observable(email.EnableAnswerInAuditTriggerNotification);

            this.EnablePush.subscribe((newVal) => {
                if (newVal === false) {
                    this.EnableNewAssignedAction(false);
                    this.EnableSelfCreatedActionComplete(false);
                    this.EnableAnswerInAuditTriggerNotification(false);
                }
            });
        }
    }

    class PushSetting {
        constructor(push) {
            this.EnablePush = ko.observable(push.EnablePush);
            this.EnableNewAssignedAction = ko.observable(push.EnableNewAssignedAction);
            this.EnableSelfCreatedActionComplete = ko.observable(push.EnableSelfCreatedActionComplete);
            this.EnableAnswerInAuditTriggerNotification = ko.observable(push.EnableAnswerInAuditTriggerNotification);
            this.EnablePush.subscribe((newVal) => {
                if (newVal === false) {
                    this.EnableNewAssignedAction(false);
                    this.EnableSelfCreatedActionComplete(false);
                    this.EnableAnswerInAuditTriggerNotification(false);
                }
            });
        }
    }

    notification.init = () => {
        self.EmailSetting = ko.observable();
        self.PushSetting = ko.observable();
    }

    notification.getData = () => {
        common.post(ActionUrl.Get_Notifcation_Settings, {}, (response) => {
            self.EmailSetting(new EmailSetting(response.Data.EmailNotificationSetting));
            self.PushSetting(new PushSetting(response.Data.PushNotificationSetting));
        });
    }

    notification.saveChanges = () => {
        var isPush = $("#liPush").hasClass("active");
        var isEmail = $("#liEmail").hasClass("active");
        var obj = null, type = "";

        if (isPush) {
            obj = self.PushSetting();
            type = "push";
        }

        if (isEmail) {
            obj = self.EmailSetting();
            type = "email";
        }

        var postData = {
            Type: type,
            EnablePush: obj.EnablePush(),
            EnableNewAssignedAction: obj.EnableNewAssignedAction(),
            EnableSelfCreatedActionComplete: obj.EnableSelfCreatedActionComplete(),
            EnableAnswerInAuditTriggerNotification: obj.EnableAnswerInAuditTriggerNotification()
        }


        common.post(ActionUrl.Save_Notifcation_Settings, JSON.stringify(postData), () => {});
    }

})(window.notification = window.notification || {}, jQuery, ko);