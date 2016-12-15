function contacterEditController($scope, contacterService, ngDialog) {
    var cec = this;
    $scope.handleEditMode = function () {
        cec.originalValue = angular.copy($scope.contacter);
        ngDialog.openConfirm({
            template:"/../App_Client/Components/Contacter/eachContacterEdit.html",
            controller: "eachContacterEditController",
            controllerAs:"ecec",
            scope: $scope,
            closeByDocument: false
            });
    };
    this.$onInit = function () {
        $scope.EditMode = false;
    }
    cec.revertContacter = function () {
        console.log("revert the contacter value");
        $scope.contacter.Name = cec.originalValue.Name;
        $scope.contacter.Telephones = cec.originalValue.Telephones;
        $scope.contacter.Id = cec.originalValue.Id;
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
