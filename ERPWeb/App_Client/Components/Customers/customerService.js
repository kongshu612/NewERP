function customerService($http,$q,progressBarDialogCtrl,confirmDialogCtrl) {
    var cds = this;
    cds.customerList = [];
    cds.loadCustomers = function () {
        var deferred = $q.defer();
        $http.get("/api/Customers")
                .then(
                    function successCallback(response) {
                        cds.customerList = response.data;
                        deferred.resolve(response);
                    },
                    function failCallback(response) {
                        deferred.reject(response);
                    }
                );
        return deferred.promise;
    };
    cds.deleteCustomer = function (customer) {
        var deferred = $q.defer();
        var progressBarParam =
            {
                titleMessage: '删除中...',
                showMessage: '正在删除客户信息...'
            };
        var loadingBarInstance = progressBarDialogCtrl.loadingBar(
            progressBarParam
            );
        $http.delete("/api/Customers/" + customer.Id)
                .then(
                    function successCallback(response) {
                        loadingBarInstance.close();
                        deferred.resolve(response);
                    },
                    function failCallback(response) {
                        loadingBarInstance.close();
                        confirmDialogCtrl.ConfirmDialog("客户信息删除出错,请尝试重新刷新页面");
                        deferred.reject(response);
                    }
                );
        return deferred.promise;
    };
    cds.addCustomer = function (customer) {
        var deferred = $q.defer();
        var progressBarParam =
            {
                titleMessage: '保存中...',
                showMessage: '正在保存客户信息...'
            };
        var loadingBarInstance = progressBarDialogCtrl.loadingBar(
            progressBarParam
            );
        $http.post("/api/Customers", customer)
                .then(
                    function successCallback(response) {
                        loadingBarInstance.close();
                        deferred.resolve(response);
                    },
                    function failCallback(response) {
                        loadingBarInstance.close();
                        confirmDialogCtrl.ConfirmDialog("客户信息保存出错,请尝试刷新页面");
                        deferred.reject();
                    }
                );
        return deferred.promise;
    };
    cds.updateCustomer = function (customer) {
        var deferred = $q.defer();
        var progressBarParam =
            {
                titleMessage: '更新中...',
                showMessage: '正在更新客户信息...'
            };
        var loadingBarInstance = progressBarDialogCtrl.loadingBar(
            progressBarParam
            );
        $http.put("/api/Customers/" + customer.Id, customer)
                .then(
                    function successCallback(response) {
                        loadingBarInstance.close();
                        deferred.resolve(response);
                    },
                    function failCallback(response) {
                        loadingBarInstance.close();
                        confirmDialogCtrl.ConfirmDialog("更新客户信息失败,请重新刷新页面");
                        deferred.reject(response);
                    }
                );
        return deferred.promise;
    };
    cds.addOrUpdateCustomer = function (customer) {
        if (customer.Id == -1) {
            return cds.addCustomer(customer);
        }
        else {
            return cds.updateCustomer(customer);
        }
    }
}
angular.module("ERPApp")
        .service("customerService", customerService);