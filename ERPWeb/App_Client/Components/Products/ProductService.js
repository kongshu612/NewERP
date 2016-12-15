function productService($q, $http) {
    var instance = this;
    instance.productList = [];
    this.LoadProduct = function () {
        deferred = $q.defer();
        $http.get("/api/Products")
                .then(
                function successCallback(response) {
                    instance.productList = response.data;
                    deferred.resolve(response);
                },
                function failCallback(response) {
                    deferred.reject(response);
                }
                );
        return deferred.promise;
    };
    this.addProduct = function (product) {
        deferred = $q.defer();
        $http.post("/api/Products", product)
               .then(
                    function successCallback(response) {
                        deferred.resolve(response);
                    },
                    function failureCallback(response) {
                        deferred.reject(response);
                    }
                   );
        return deferred.promise;
    };
    this.deleteProduct = function (product) {
        deferred = $q.defer();
        $http.delete("/api/Products/" + product.Id, product)
                .then(
                    function successCallback(response) {
                        deferred.resolve(response);
                    },
                    function failCallback(response) {
                        deferred.reject(response);
                    }
                );
        return deferred.promise;
    };
    this.updateProduct = function (product) {
        deferred = $q.defer();
        $http.put("/api/Products/" + product.Id, product)
                .then(
                    function successCallback(response) {
                        deferred.resolve(response);
                    },
                    function failurCallback(response) {
                        deferred.reject(response);
                    }
                );
        return deferred.promise;
    }
}
angular.module("ERPApp").service("productService", productService);