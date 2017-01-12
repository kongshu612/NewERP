function contacterService($q, $http, progressBarDialogCtrl, confirmDialogCtrl) {
    var cs = this;
    cs.deleteContacter = function (customerId, contacterId) {
        var defer = $q.defer();
        if (customerId == -1) {
            defer.resolve();
        }
        else {
            var progressBarParam =
                {
                    titleMessage: '删除中...',
                    showMessage: '正在删除联系人信息...'
                };
            var loadingBarInstance = progressBarDialogCtrl.loadingBar(
                progressBarParam
                );
            $http.delete("/api/customers/" + customerId + "/contacters/" + contacterId)
                    .then(
                        function successCallback(response) {
                            loadingBarInstance.close();
                            defer.resolve(response);
                        },
                        function failCallback(response) {
                            loadingBarInstance.close();
                            confirmDialogCtrl.ConfirmDialog("联系人删除出错,请尝试重新刷新页面");
                            defer.reject(response);
                        }
                    );
        }
        return defer.promise;
    };
    cs.updateContacter = function (contacter) {
        var defer = $q.defer();
        if (contacter.CustomerId == -1) {
            defer.resolve(contacter);
        }
        else {
            var progressBarParam =
                {
                    titleMessage: '更新中...',
                    showMessage: '正在更新联系人信息...'
                };
            var loadingBarInstance = progressBarDialogCtrl.loadingBar(
                progressBarParam
                );
            $http.put("/api/contacters/" + contacter.Id, contacter)
                    .then(
                        function successCallback(response) {
                            loadingBarInstance.close();
                            defer.resolve(response.data);
                        },
                        function failCallback(response) {
                            loadingBarInstance.close();
                            confirmDialogCtrl.ConfirmDialog("更新联系人信息失败,请重新刷新页面");
                            defer.reject(response.data)
                        }
                    );
        }
        return defer.promise;
    };
    cs.AddContacter = function (customerId, contacter) {
        var defer = $q.defer();
        if (customerId == -1) {
            defer.resolve(contacter);
        }
        else {
            var progressBarParam =
                {
                    titleMessage: '保存中...',
                    showMessage: '正在保存联系人信息...'
                };
            var loadingBarInstance = progressBarDialogCtrl.loadingBar(
                progressBarParam
                );
            $http.post("/api/customers/" + customerId + "/contacters", contacter)
                    .then(
                        function successCallback(response) {
                            loadingBarInstance.close();
                            defer.resolve(response.data);
                        },
                        function failCallback(response) {
                            loadingBarInstance.close();
                            confirmDialogCtrl.ConfirmDialog("联系人保存出错");
                            defer.reject(response.data);
                        }
                    );
        }
        return defer.promise;
    };
    cs.addOrUpdateContacter = function (contacter) {
        if (contacter.Id == -1) {
            return cs.AddContacter(contacter.CustomerId, contacter);
        }
        else {
            return cs.updateContacter(contacter);
        }
    }
};
angular.module("ERPApp")
        .service("contacterService", contacterService);