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
function orderDetailController($scope, ngDialog, orderService, confirmDialogCtrl, progressBarDialogCtrl) {
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
        odc.editDialog.catch(
            function failCallback() {
                $scope.order = odc.originalOrderValue;
            });
    };
}
function orderDetailDirective(){
    return {
        scope: {
            order: "=",
            deleteOrder: "&"
        },
        controller: orderDetailController,
        controllerAs: "ODC",
        templateUrl:"/../App_Client/Components/Orders/orderDetail.html"
    }
}


angular.module("ERPApp")
         .directive("orderDetail",orderDetailDirective);