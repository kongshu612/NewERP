function customerDetailDiretive() {
    return {
        templateUrl: "/../App_Client/Components/Customers/customerDetail.html",
        controller: customerDetailController,
        controllerAs: "cdc",
        scope:{
            customer:"=",
            index: "=",
            catalogList: "=",
            removeCustomer: "&"
        }
    }
}
function closingCustomerDialog(e, $dialog) {
    e.currentScope.cdc.updateCustomer();    
}
function customerDetailController($scope, customerService, catalogService, ngDialog, confirmDialogCtrl) {
    cdc = this;
    cdc.handleEditMode = function () {
        $scope.originalcustomer = angular.copy($scope.customer);
        var ngDialogInstance = ngDialog.openConfirm({
            template: "/../App_Client/Components/Customers/customerEdition.html",
            controller: "customerEditionDialogController",
            className: "ngdialog-theme-default ngdialog-theme-custom",
            scope: $scope,
            closeByDocument: false,
            showClose: false
        });
        ngDialogInstance.catch(function () {
            $scope.originalcustomer.contacters = $scope.customer.contacters;
            $scope.customer = $scope.originalcustomer;
                        });
    };
   
  //  $scope.$on('ngDialog.closing', closingCustomerDialog);
    cdc.loadCatalog = function () {
        catalogService.Load()
                    .then(
                        function successCallback(response) {
                            cdc.catalogList = response.data;
                        },
                        function failCallback(response) {
                            console.log("request calalog error");
                        }
                    );
    }
    cdc.$onInit = function () {
        cdc.loadCatalog();
    };
    cdc.updateCustomer = function () {
        customerService.updateCustomer($scope.customer)
                    .then(
                        function successCallback(response) {
                        },
                        function failCallback(response) {
                            confirmDialogCtrl.ConfirmDialog("更新客户信息失败，请稍后再试！");
                        }
                    );
    };   
}
angular.module("ERPApp")
        .directive("customerDetail", customerDetailDiretive);