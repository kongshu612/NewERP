function customerService($http,$q) {
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
        $http.delete("/api/Customers/" + customer.Id)
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
    cds.addCustomer = function (customer) {
        var deferred = $q.defer();
        $http.post("/api/Customers", customer)
                .then(
                    function successCallback(response) {
                        deferred.resolve(response);
                    },
                    function failCallback(response) {
                        alert("add new customer fail");
                    }
                );
        return deferred.promise;
    };
    cds.updateCustomer = function (customer) {
        var deferred = $q.defer();
        $http.put("/api/Customers/" + customer.Id, customer)
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
}
angular.module("ERPApp")
        .service("customerService", customerService);