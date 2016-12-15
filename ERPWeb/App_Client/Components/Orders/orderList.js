function orderListController($scope,orderService) {
    var olc = this;
    olc.refresh = function () {
        olc.isError = false;
        olc.isLoaded = false;
        olc.orderList = [];
        orderService.getOrderList()
                    .then(
                        function successCallback(response) {
                            olc.isLoaded = true;
                            olc.orderList = response.data;
                        },
                        function failCallback(response) {
                            olc.isError = true;
                            console.log("error occur while loading orderList");
                        }
                    );
    }
    olc.add = function () {

    };
    olc.deleteOrder = function (order) {

    }
    olc.$onInit = function () {
        // olc.refresh();
        olc.isLoaded = true;
        olc.orderList = [
            { OrderId: 1, CreatedTime: Date(), SentTime: Date(), IsPayed: true, TotalPrice: 1000, Product: { Name: "product1", Id: 1 }, Customer: { Name: "customer1", Id: 1, Contacters: [{ Name: "contacter1", Id: 1 }, { Name: "contacter2", Id: 2 }] }, Contacter: { Id: 1, Name: "contacter1" } },
            { OrderId: 2, CreatedTime: Date(), SentTime: Date(), IsPayed: false, TotalPrice: 1000, Product: { Name: "product2", Id: 2 }, Customer: { Name: "customer2", Id: 2, Contacters: [{ Name: "contacter3", Id: 3 }, { Name: "contacter4", Id: 4 }] }, Contacter: { Id: 3, Name: "contacter3" } }
        ]
    }
}

angular.module("ERPApp")
        .component("orderList", {
            controller: orderListController,
            controllerAs: "OLC",
            templateUrl:"/../App_Client/Components/Orders/orderList.html"
        });
