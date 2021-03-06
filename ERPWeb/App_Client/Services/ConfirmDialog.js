﻿function confirmDialogCtrl(ngDialog) {
    var CDCtrl = this;
    
    CDCtrl.ConfirmDialog = function (message) {
        var ngDialogInstance = ngDialog.openConfirm({
            plain: true,
            className: "ngdialog-theme-default ngdialog-theme-custom",
            closeByDocument: false,
            showClose: false,
            template: `
                <div class="modal-header">
                     <h3 class ="modal-title">
                        <span class ="fa fa-error"></span><b>警告</b>
                     </h3>
                </div>
                <div class ="modal-body">
                    <p>` + message + `</p>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-primary" type="button" ng-click="confirm()">确定</button>
                </div>
                `
        });
    };

    CDCtrl.DeleteConfirmDialog = function (message) {
        var ngDialogInstance = ngDialog.openConfirm({
            plain: true,
            className: "ngdialog-theme-default ngdialog-theme-custom",
            closeByDocument: false,
            showClose: false,
            template: `
                <div class="modal-header">
                     <h3 class ="modal-title">
                        <span class ="fa fa-error"></span><b>警告</b>
                     </h3>
                </div>
                <div class ="modal-body">
                    <p>` + message + `</p>
                </div>
                <div class="modal-footer">
                    <button class ="btn btn-primary" type="button" ng-click="confirm()">确定</button>
                    <button class = "btn btn-info" type="button" ng-click="closeThisDialog()">取消</button>
                </div>
                `
        });
        return ngDialogInstance;
    };
}



angular.module('ERPApp')
        .service('confirmDialogCtrl', confirmDialogCtrl);