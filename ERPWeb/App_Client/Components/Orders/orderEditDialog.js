function orderEditDialogController($scope, productService, customerService, orderService) {
    if (productService.productList.length == 0) {
        productService.LoadProduct().then(
            function (response) {
                $scope.productList = productService.productList;
            },
            function (response) {
                console.log("error occue while loading the productList");
            }
        );
    } else {
        $scope.productList = productService.productList;
    }
    if (customerService.customerList.length == 0) {
        customerService.loadCustomers().then(
                function (response) {
                    $scope.customerList = customerService.customerList;
                },
                function (response) {
                    console.log("error occure whild loading the customer list");
                }
            );
    }
    else {
        $scope.customerList = customerService.customerList;
    }
    $scope.sentTimePickerShow = false;
    $scope.createdTimePickerShow = false;
    $scope.dateOptions = {
        formatYear: 'yy',
        startingDay: 1,
        datepickerMode: 'day'
    };
    $scope.showCalendar = function (calendarType) {
        switch (calendarType) {
            case "CreatedTime": $scope.createdTimePickerShow = true; break;
            case "SentTime": $scope.sentTimePickerShow = true; break;
        }
    }
    $scope.showCalendarForSentTime = function () {
        $scope.sentTimePickerShow = true;
    };
    $scope.showCalendarForCreatedTime = function () {
        $scope.createdTimePickerShow = true;
    }
    $scope.confirmButtonClick = function () {
        orderService.addOrUpdate($scope.order)
        .then(
        function successCallback(order) {
            $scope.confirm(order);
        },
        function failCallback(order) {
            $scope.closeThisDialog(order);
        }
        );
    }
    $scope.cancelButtonClick = function () {
        $scope.closeThisDialog($scope.order);
    }
}


        