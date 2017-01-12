function orderServiceDef($http, $q, $filter, progressBarDialogCtrl,confirmDialogCtrl) {
    var osd = this;
    osd.getOrderList = function () {
        var defer = $q.defer();
        $http.get("/api/orders")
                .then(
                    function successCallback(response) {
                        defer.resolve(response);
                    },
                    function failCallback(response) {
                        defer.reject(response);
                    }
                );
        return defer.promise;
    };
    osd.updateOrder = function (order) {
        var defer = $q.defer();
        var progressBarParam =
            {
                titleMessage: '更新中...',
                showMessage: '正在更新订单信息...'
            };
        var loadingBarInstance = progressBarDialogCtrl.loadingBar(
            progressBarParam
            );
        $http.put("/api/orders/" + order.OrderId, order)
            .then(
                function successCallback(response) {
                    loadingBarInstance.close();
                    defer.resolve(response);
                },
                function failCallback(response) {
                    loadingBarInstance.close();
                    confirmDialogCtrl.ConfirmDialog("更新订单信息失败,请重新刷新页面");
                    defer.reject(response);
                }
            );
        return defer.promise;
    };
    osd.createOrder = function (order) {
        var defer = $q.defer();
        var progressBarParam =
            {
                titleMessage: '保存中...',
                showMessage: '正在保存订单信息...'
            };
        var loadingBarInstance = progressBarDialogCtrl.loadingBar(
            progressBarParam
            );
        $http.post("/api/orders/",order)
            .then(
                function successCallback(response) {
                    loadingBarInstance.close();
                    defer.resolve(response);
                },
                function failCallback(response) {
                    loadingBarInstance.close();
                    confirmDialogCtrl.ConfirmDialog("订单信息保存出错,请尝试刷新页面");
                    defer.reject(response);
                }
            );
        return defer.promise;
    }
    osd.deleteOrder = function (orderId) {
        var defer = $q.defer();
        var progressBarParam =
            {
                titleMessage: '删除中...',
                showMessage: '正在删除订单信息...'
            };
        var loadingBarInstance = progressBarDialogCtrl.loadingBar(
            progressBarParam
            );
        $http.delete("/api/orders/" + orderId)
            .then(
                function successCallback(response) {
                    loadingBarInstance.close();
                    defer.resolve(response);
                },
                function failCallback(response) {
                    loadingBarInstance.close();
                    confirmDialogCtrl.ConfirmDialog("订单信息删除出错,请尝试重新刷新页面");
                    defer.reject(response);
                }
            );
        return defer.promise;
    }
    osd.addOrUpdate = function (order) {
        if (order.OrderId == -1) {
            return osd.createOrder(order);
        }
        else {
            return osd.updateOrder(order);
        }
    }
}


angular.module("ERPApp")
        .service("orderService", orderServiceDef);