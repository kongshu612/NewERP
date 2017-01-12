function catalogService($http, $q) {
    var cs = this;
    cs.CatalogList = [];
    cs.Load = function () {
        var deferred = $q.defer();
        $http.get("/api/catalogs")
            .then(
                function successCallback(response) {
                    cs.CatalogList = response.data;
                    deferred.resolve(response);
                },
                function failCallback(response) {
                    cs.CatalogList = [];
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
                    cs.CatalogList.push(response.data);
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
                        var targetIndex = -1;
                        cs.CatalogList.forEach(function (element, index, array) {
                            if (element.Id == catalogId) {
                                targetIndex = index;
                            }
                        });
                        if (targetIndex != -1) {
                            cs.CatalogList.splice(targetIndex, 1);
                        }
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
                        cs.CatalogList.forEach(
                            function (element, index, array) {
                                if (element.Id == response.data.Id) {
                                    element.Name = response.data.Name;
                                    element.Description = response.data.Description;
                                }
                            });
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