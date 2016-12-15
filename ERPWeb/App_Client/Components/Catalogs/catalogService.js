function catalogService($http, $q) {
    var cs = this;
    cs.Load = function () {
        var deferred = $q.defer();
        $http.get("/api/catalogs")
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
    cs.addCatalog = function (catalog) {
        var deferred = $q.defer();
        $http.post("/api/catalogs", catalog)
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
    cs.deleteCatalog = function (catalogId) {
        var deferred = $q.defer();
        $http.delete("/api/catalogs/" + catalogId)
                .then(
                    function successfullCallback(response) {
                        deferred.resolve(response);
                    },
                    function failCallback(response) {
                        deferred.reject(response);
                    }
                );
        return deferred.promise;
    };
    cs.updateCatalog = function (catalog) {
        var deferred = $q.defer();
        $http.put("/api/catalogs/" + catalog.Id,catalog)
                .then(
                    function successCallback(response) {
                        deferred.resolve(response);
                    },
                    function failCallback(response) {
                        deferred.reject(response);
                    }
                );
        return deferred.promise;
    }
}

angular.module("ERPApp")
        .service("catalogService", catalogService);