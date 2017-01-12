function eachContacterEditController($scope, contacterService,confirmDialogCtrl) {
    var ecec = this;
    ecec.save = function () {
        contacterService.addOrUpdateContacter($scope.contacter)
                        .then(
                            function successCallback(response) {
                                $scope.confirm(response);
                            },
                            function failCallback(response) {
                                $scope.closeThisDialog();
                            }
                        );
    };
    ecec.cancel = function () {
        $scope.closeThisDialog();
    };
}
angular.module("ERPApp")
        .controller("eachContacterEditController", eachContacterEditController);