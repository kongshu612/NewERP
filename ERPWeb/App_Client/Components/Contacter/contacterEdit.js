function contacterEditController($scope, contacterService, ngDialog) {
    var cec = this;
    $scope.handleEditMode = function () {
        cec.originalValue = angular.copy($scope.contacter);
        var updateContacterInstance = ngDialog.openConfirm({
            template:"/../App_Client/Components/Contacter/eachContacterEdit.html",
            controller: "eachContacterEditController",
            controllerAs:"ecec",
            scope: $scope,
            closeByDocument: false
        });
        updateContacterInstance.then(function successCallback(response) {
            $scope.contacter = response;
        },
        function failCallback(response) {
            $scope.contacter = angular.copy(cec.originalValue);
            confirmDialogCtrl.ConfirmDialog("更新联系人失败");
        });
    };
    this.$onInit = function () {
        $scope.EditMode = false;
    }
    cec.revertContacter = function () {
        $scope.contacter = angular.copy(cec.originalValue);
    }
};
function contacterEditDirective() {
    return {
        templateUrl: "/../App_Client/Components/Contacter/contacterEdit.html",
        controller: contacterEditController,
        controllerAs: "contacterEditCtrl",
        scope: {
            contacter: "=",
            deleteContacter: "&deleteContacter"
        }
    };
};

angular.module("ERPApp")
        .directive("contacterEdit", contacterEditDirective);
