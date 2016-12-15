function customerListController($scope, customerService,catalogService) {
    cuc = this;
    cuc.reflesh = function () {
        cuc.loading = true;
        cuc.error = false;
        cuc.customerList = [];
        cuc.catalogList = [];
        customerService.loadCustomers()
                                .then(
                                    function successCallback(response) {
                                        cuc.customerList = response.data;
                                    },
                                    function failCallback(reponse) {
                                        cuc.loading = false;
                                        cuc.error = true;
                                    }
                                );
        catalogService.Load()
                    .then(
                        function successCallback(response) {
                            cuc.catalogList = response.data;
                            cuc.loading = false;
                        },
                        function failCallback(response) {
                            console.log("request calalog error");
                        }
                    );
        
    };
    cuc.removeCustomer = function (c) {
        index = cuc.customerList.indexOf(c);
        if (index >= 0) {
            customerService.deleteCustomer(c)
                            .then(
                                function successCallback(response) {
                                    cuc.customerList.splice(index, 1);
                                },
                                function failCallback(response) {
                                    alert("Can not find the customer with server side error");
                                }
                            )
        }
        else {
            alert("Can not find the customer");
        }
    };
    cuc.add = function () {
        newCustomer = { Id: -1, Name: "", Address: "", Description: "", Catalog: {}, Credit: "", Contacters: [] };
        customerService.addCustomer(newCustomer)
                        .then(
                            function successCallback(response) {
                                cuc.customerList.push(response.data);
                            },
                            function failCallback(response) {
                                alert("failed to add new customer");
                            }
                        );
    };
    cuc.$onInit = function () {
        cuc.reflesh();
    };
};
angular.module("ERPApp")
        .component("customerList", {
            templateUrl: "/../App_Client/Components/Customers/customerList.html",
            controller: customerListController,
            controllerAs:"cuc"
        })