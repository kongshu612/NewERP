function orderServiceDef($http,$q) {
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
        $http.put("/api/orders/" + order.OrderId, order)
            .then(
                function successCallback(response) {
                    defer.resolve(response);
                },
                function failCalback(response) {
                    defer.reject(response);
                }
            );
        return defer.promise;
    };
}


angular.module("ERPApp")
        .service("orderService", orderServiceDef);