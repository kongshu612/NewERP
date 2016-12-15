function orderEditDialogClosing(e,$dialog)
{
    //if (e.currentScoep.ODC.save) {
    //    //console.log("save");
    //}
    //else {
    //    //console.log("cancel");
    //}
}
function orderEditDialogCancel(e,$dialog){

}
function orderDetailController($scope, ngDialog, orderService) {
    var odc = this;
    odc.originalOrderValue = angular.copy($scope.order);
    odc.save = true;
    odc.edit = function () {
        odc.editDialog = ngDialog.openConfirm(
            {
                template: "/../App_Client/Components/Orders/orderEditDialog.html",
                controller: orderEditDialogController,
                ControllerAs:"OEDC",
                className: "ngdialog-theme-default ngdialog-theme-custom",
                scope: $scope,
                closeByDocument: false,
                width: 500,
                showClose: false
            });
        odc.editDialog.then(
            function successCallback() {
                console.log("save");
                odc.progressBar = ngDialog.open(
                    {
                        template: '<uib-progressbar style="height:40px" class="progress-striped active" value="100" type="info"><i>保存中...</i></uib-progressbar>',
                        plain:true,
                        controller: progressBarController,
                        className: "ngdialog-theme-default ngdialog-theme-custom",
                        scope: $scope,
                        closeByDocument: false,
                        showClose: false
                    });
                orderService.updateOrder($scope.order).then(
                    function () {
                        console.log("update complete");
                        odc.progressBar.close();
                    },
                    function () {
                        console.log("update failure");
                        $scope.order = odc.originalOrderValue;
                        odc.progressBar.close();
                        odc.warningDialog = ngDialog.open(
                            {
                                template: '<div><p><i class="fa  fa-exclamation-triangle"></i><b>保存失败</b></p>\
                                           <button class="glyphicon glyphicon-ok" ng-click="closeThisDialog()">确定</button>   \
                                            </div>',
                                plain: true,
                                className: "ngdialog-theme-default ngdialog-theme-custom",
                                closeByDocument: false,
                                showClose: false,
                                width:100
                            });
                    }
                );
            },
            function failCallback() {
                console.log("cancel");
                $scope.order = odc.originalOrderValue;
            });
    };
    odc.delete = function () {

    };
}
function orderDetailDirective(){
    return {
        controller: orderDetailController,
        controllerAs: "ODC",
        scope: {
            order: "=",
            deleteOrder:"&"
        },
        templateUrl:"/../App_Client/Components/Orders/orderDetail.html"
    }
}


angular.module("ERPApp")
         .directive("orderDetail",orderDetailDirective);