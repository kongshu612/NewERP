function confirmDialogCtrl($uibModal) {
    var CDCtrl = this;
    CDCtrl.ConfirmDialog = function (message) {
        var modalInstance = $uibModal.open(
        {
            animation: true,
            template: `
                <div class="modal-header">
                     <h3 class ="modal-title" >
                        <span class ="fa fa-error"></span><b>警告</b>
                     </h3>
                </div>
                <div class ="modal-body">
                    <p>` + message + `</p>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-primary" type="button" ng-click="$close()">确定</button>
                </div>
                ` 
        });

    };
}



angular.module('ERPApp')
        .service('confirmDialogCtrl', confirmDialogCtrl);