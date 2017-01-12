function progressBarDialogCtrl(ngDialog) {
    var PBDC = this;
    PBDC.loadingBar = function (param) {
        var loadingBarInstance = ngDialog.open(
        {
            plain: true,
            className: "ngdialog-theme-default ngdialog-theme-custom",
            closeByDocument: false,
            showClose: false,
            template: `
                <uib-progressbar animate='true' class ="progress-striped active" type="info" value=100 title="`
                + param.titleMessage +
                `" >` + param.showMessage + `</uib-progressbar>
                `
        }
        );
        return loadingBarInstance;
    }
}



angular.module('ERPApp')
    .service('progressBarDialogCtrl', progressBarDialogCtrl);