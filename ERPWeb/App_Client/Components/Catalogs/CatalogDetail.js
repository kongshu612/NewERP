function catalogDetailController($scope, CRUDService, confirmDialogCtrl) {
    var cd = this;
    $scope.editMode = false;
    cd.handleEdit = function () {
        if ($scope.editMode) {
            CRUDService.update("/api/catalogs/"+$scope.catalog.Id,$scope.catalog)
                            .then(
                            function successCallback(response) {
                                $scope.catalog.Id = response.data.Id;
                                $scope.catalog.Name = response.data.Name;
                                $scope.catalog.Description = response.data.Description;
                            }, function failCallback(response) {
                                confirmDialogCtrl.ConfirmDialog("客户类型更新出错啦");
                                $scope.catalog.Id = $scope.originalCatalog.Id;
                                $scope.catalog.Name = $scope.originalCatalog.Name;
                                $scope.catalog.Description = $scope.originalCatalog.Description;
                            }
                            );
        }
        else {
            $scope.originalCatalog = angular.copy($scope.catalog);
        }
        $scope.editMode = !$scope.editMode;
    };
}

function catalogDetailDirective() {
    return {
        scope: {
            catalog: "=eachCatalog",
            deleteCatalog: "&"
        },
        templateUrl: "/../App_Client/Components/Catalogs/CatalogDetail.html",
        controller: catalogDetailController,
        controllerAs:"cd"
    }
}
angular.module("ERPApp")
        .directive("catalogDetail", catalogDetailDirective);