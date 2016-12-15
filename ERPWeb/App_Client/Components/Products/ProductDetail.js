function ProductDetailDirective() {
    return {
        scope: {
            product: "=",
            deleteProduct: "&"
        },
        templateUrl: "/../App_Client/Components/Products/ProductDetail.html",
        controller: "productDetailController",
        controllerAs: "pdc"
        
    }
}
function productDetailController($scope, CRUDService, confirmDialogCtrl) {
    pdc = this;
    $scope.editMode = false;
    pdc.HandleModeChange = function () {
        if ($scope.editMode) {
            CRUDService.update("/api/products/" + $scope.product.Id, $scope.product)
                        .then(
                            function successCallback(response) {
                                $scope.product.Id = response.data.Id;
                                $scope.product.Name = response.data.Name;
                                $scope.product.Size = response.data.Size;
                                $scope.product.Count = response.data.Count;
                            },
                            function failureCallback(response) {
                                // alert("更新出错啦" + response.status);
                                confirmDialogCtrl.ConfirmDialog("更新出错啦");
                                $scope.product.Id = pdc.originalProduct.Id;
                                $scope.product.Name = pdc.originalProduct.Name;
                                $scope.product.Size = pdc.originalProduct.Size;
                                $scope.product.Count = pdc.originalProduct.Count;
                            }
                        );
        }
        else {
            pdc.originalProduct = angular.copy($scope.product);
        }
        $scope.editMode = !$scope.editMode;
    }
}

angular.module("ERPApp")
    .controller("productDetailController", productDetailController)
    .directive("productDetail", ProductDetailDirective)