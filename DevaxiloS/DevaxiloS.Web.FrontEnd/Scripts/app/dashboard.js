(function (dashboard, $, ko, undefined) {

    var self = this;

    class Device {
        constructor(device) {
            this.Id = device.Id;
            this.Name = device.Name;
            this.CreatedAt = common.parseDate(device.CreatedAt);
        }
    }

    class Template {
        constructor(template) {
            this.Id = template.Id;
            this.Name = template.Name;
            this.Thumbnail = template.Thumbnail;
            this.Description = template.Description;
        }
    }

    class Audit {
        constructor(audit) {
            this.Id = audit.Id;
            this.Name = audit.Name;
            this.Thumbnail = audit.Thumbnail;
            this.Score = audit.CalculatedScore < 0 ? "N/A" : audit.CalculatedScore.toString();
            this.ModifiedAt = audit.ModifiedAt ? common.parseDate(audit.ModifiedAt) : null;
        }
    }

    dashboard.init = () => {
        self.Devices = ko.observableArray([]);
        self.Templates = ko.observableArray([]);
        self.Audits = ko.observableArray([]);
        self.SelectedDeviceId = null;
    }

    dashboard.getData = () => {
        common.post(ActionUrl.Get_Dashboard_Data, {}, (response) => {
            self.Devices(_.map(response.Data.Devices, function (device) {
                return new Device(device);
            }));

            self.Templates(_.map(response.Data.Templates, function (template) {
                return new Template(template);
            }));

            self.Audits(_.map(response.Data.Audits, function (audit) {
                return new Audit(audit);
            }));
        });
    }

    dashboard.askRemoveDevice = (device, evt) => {
        self.SelectedDeviceId = device.Id;
        $(evt.target).confirmation({ rootSelector: "[data-toggle=confirmation]" }).confirmation("toggle");
    }

    dashboard.removeDevice = () => {
        var deviceId = self.SelectedDeviceId;
        var postData = {
            id: deviceId
        };

        common.post(ActionUrl.Remove_Device, JSON.stringify(postData), (response) => {
            if (!response.IsError) {
                self.Devices.remove(function (device) {
                    return device.Id === deviceId;
                });
                self.SelectedDeviceId = null;
            }
        });
    }

})(window.dashboard = window.dashboard || {}, jQuery, ko);