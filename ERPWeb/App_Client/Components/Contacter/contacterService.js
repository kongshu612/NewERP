function contacterService($q, $http) {
    var cs = this;
    cs.deleteContacter = function (customerId, contacterId) {
        var defer = $q.defer();
        $http.delete("/api/customers/" + customerId + "/contacters/" + contacterId)
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
    cs.updateContacter = function (contacter) {
        var defer = $q.defer();
        $http.put("/api/contacters/" + contacter.Id, contacter)
                .then(
                    function successCallback(response) {
                        defer.resolve(response);
                    },
                    function failCallback(response) {
                        defer.reject(response)
                    }
                );
        return defer.promise;
    };
    cs.AddContacter = function (customerId, contacter) {
        var defer = $q.defer();
        $http.post("/api/customers/" + customerId + "/contacters", contacter)
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
};
angular.module("ERPApp")
        .service("contacterService", contacterService);