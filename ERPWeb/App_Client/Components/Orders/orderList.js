function orderListController($scope,ngDialog, orderService,productService,customerService, confirmDialogCtrl, progressBarDialogCtrl) {
    var olc = this;
    olc.refresh = function () {
        olc.isError = false;
        olc.isLoaded = false;
        olc.orderList = [];
        productService.LoadProduct().catch(function () { olc.isError = true; });
        customerService.loadCustomers().catch(function () { olc.isError = true; });
        orderService.getOrderList()
                    .then(
                        function successCallback(response) {
                            olc.isLoaded = true;
                            olc.orderList = response.data;
                            olc.orderList.forEach(function (currentValue, index, array) {
                                array[index].CreatedTime = new Date(currentValue.CreatedTime);
                                array[index].SentTime = currentValue.SentTime==null ? null : new Date(currentValue.SentTime);
                            })
                        },
                        function failCallback(response) {
                            olc.isError = true;
                        }
                    );
    }
    olc.add = function () {
        if(productService.productList.length==0){
            confirmDialogCtrl.ConfirmDialog("请确定是否有产品信息添加到当前系统，或者刷新页面重新尝试");
            return;
        }
        if (customerService.customerList.length == 0) {
            confirmDialogCtrl.ConfirmDialog("请确定是否有客户信息添加到当前系统，或者刷新页面重新尝试");
            return;
        }
        $scope.order = {
            OrderId:-1,
            Description: "",
            ExpressId: "",
            DestinationAddress: "",
            CreatedTime: new Date(),
            SentTime: null,
            IsPayed: false,
            TotalPrice: 0,
            Count: 0,
            Product: productService.productList[0],
            Customer: customerService.customerList[0],
            Contacter: customerService.customerList[0].Contacters[0]
        }
        olc.createdOrderDialog = ngDialog.openConfirm(
        {
            template: "/../App_Client/Components/Orders/orderEditDialog.html",
            controller: orderEditDialogController,
            ControllerAs:"OEDC",
            className: "ngdialog-theme-default ngdialog-theme-custom",
            scope: $scope,
            closeByDocument: false,
            width: 500,
            showClose: false
        });
        olc.createdOrderDialog.then(
            function successCallback(responsedOrder) {
                olc.orderList.push($scope.order);                
            },
            function failCallback() {
                $scope.order = {};
            });
    };
    olc.deleteOrder = function (order) {
        var index = olc.orderList.indexOf(order);
        var ngDialogInstance = confirmDialogCtrl.DeleteConfirmDialog("确定要删除选择的订单吗？");
        ngDialogInstance.then(function () {
            if (order.OrderId == 0) {
                olc.orderList.splice(index, 1);
            }
            else {
                orderService.deleteOrder(order.OrderId)
                            .then(
                                function successCallback(response) {
                                    olc.orderList.splice(index, 1);
                                }
                            );
            }
        });
    }
    olc.$onInit = function () {
        olc.refresh();
    }

}

angular.module("ERPApp")
        .component("orderList", {
            controller: orderListController,
            controllerAs: "OLC",
            templateUrl:"/../App_Client/Components/Orders/orderList.html"
        });
