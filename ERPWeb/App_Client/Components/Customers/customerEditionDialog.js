function customerEditionDialogContrller(ngDialog, $scope, confirmDialogCtrl, customerService) {
    var cedc = this;
    $scope.confirmButtonClick = function () {
        if ($scope.customer.Catalog == null) {
            confirmDialogCtrl.ConfirmDialog("请为该客户选择一个有效的类别后再保存");
            return;
        }
        if ($scope.customer.Contacters.length == 0) {
            confirmDialogCtrl.ConfirmDialog("请至少为该客户提供一个联系人后再保存");
            return;
        }
        customerService.addOrUpdateCustomer($scope.customer)
                        .then(
                            function successCallback(response) {
                                $scope.customer = response.data;
                                $scope.confirm();
                            },
                            function failCallback(response) {
                                confirmDialogCtrl.ConfirmDialog("保存客户信息失败");
                            }
                        );
    }
    $scope.cancelButtonClick = function () {
        $scope.closeThisDialog();
    }
    };

angular.module("ERPApp")
        .controller("customerEditionDialogController", customerEditionDialogContrller);