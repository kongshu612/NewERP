function customerListController($scope,ngDialog, customerService,catalogService,confirmDialogCtrl) {
    cuc = this;
    cuc.reflesh = function () {
        cuc.loading = true;
        cuc.error = false;
        cuc.customerList = [];
        cuc.catalogList = [];
        customerService.loadCustomers()
                                .then(
                                    function successCallback(response) {
                                        cuc.customerList = response.data;
                                    },
                                    function failCallback(reponse) {
                                        cuc.loading = false;
                                        cuc.error = true;
                                    }
                                );
        catalogService.Load()
                    .then(
                        function successCallback(response) {
                            cuc.catalogList = response.data;
                            cuc.loading = false;
                        },
                        function failCallback(response) {
                            cuc.error = true;
                        }
                    );
        
    };
    cuc.removeCustomer = function (c) {
        var index = cuc.customerList.indexOf(c);
        if (index >= 0) {
            var ngDialogInstance = confirmDialogCtrl.DeleteConfirmDialog("确定要删除选择的客户信息吗？");
            ngDialogInstance.then(function () {
                customerService.deleteCustomer(c)
                                .then(
                                    function successCallback(response) {
                                        cuc.customerList.splice(index, 1);
                                    },
                                    function failCallback(response) {
                                        confirmDialogCtrl.ConfirmDialog("删除客户记录失败,请稍后尝试，如继续失败请联系，技术支持");
                                    }
                                )
            });
        }
        else {
            alert("Can not find the customer");
        }
    };
    cuc.add = function () {
        if (catalogService.CatalogList.length == 0) {
            confirmDialogCtrl.ConfirmDialog("请确定是否有客户类别添加到当前系统，或者刷新页面重新尝试");
            cuc.Error = true;
        }
        $scope.catalogList = catalogService.CatalogList;
        $scope.originalCustomer = { Id: -1, Name: "", Address: "", Description: "", Catalog: catalogService.CatalogList[0], Credit: "", Contacters: [] };
        $scope.customer = angular.copy($scope.originalCustomer);
        var ngDialogInstance = ngDialog.openConfirm({
            template: "/../App_Client/Components/Customers/customerEdition.html",
            controller: "customerEditionDialogController",
            className: "ngdialog-theme-default ngdialog-theme-custom",
            scope: $scope,
            closeByDocument: false,
            showClose:false
        });
        ngDialogInstance.then(
            function successCallback() {
                cuc.customerList.push($scope.customer);
                $scope.customer = {};
                $scope.originalCustomer = {};
            },
            function failCallback() {
                $scope.customer = {};
                $scope.originalCustomer = {};
                
            });
    };
    cuc.$onInit = function () {
        cuc.reflesh();
    };
};
angular.module("ERPApp")
        .component("customerList", {
            templateUrl: "/../App_Client/Components/Customers/customerList.html",
            controller: customerListController,
            controllerAs:"cuc"
        })