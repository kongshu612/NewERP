function eachContacterEditController($scope, contacterService,confirmDialogCtrl) {
    var ecec = this;
    ecec.save = function () {
        contacterService.updateContacter($scope.contacter)
                        .then(
                            function successCallback(response) {
                                $scope.confirm();
                            },
                            function failCallback(response) {
                                confirmDialogCtrl.ConfirmDialog("更新联系人信息失败，请稍后再试！");
                                console.log("update the contacter fail.revert back");
                                $scope.contacterEditCtrl.revertContacter();
                                $scope.closeDialog();
                            }
                        );
    };
    ecec.cancel = function () {
        $scope.contacterEditCtrl.revertContacter();
        $scope.closeThisDialog();
    };
}
angular.module("ERPApp")
        .controller("eachContacterEditController", eachContacterEditController);