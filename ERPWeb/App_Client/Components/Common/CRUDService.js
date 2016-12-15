function CRUDService($q, $http) {
    this.Load = function (api) {
        var deferred = $q.defer();
        $http.get(api)
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
    this.add = function (api,insertedValue) {
        var deferred = $q.defer();
        $http.post(api, insertedValue)
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
    this.delete = function (api,deletedValue) {
        var deferred = $q.defer();
        $http.delete(api, deletedValue)
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
    this.update = function (api,updatedValue) {
        var deferred = $q.defer();
        $http.put(api, updatedValue)
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
angular.module("ERPApp").service("CRUDService", CRUDService);