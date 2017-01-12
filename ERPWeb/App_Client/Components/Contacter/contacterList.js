function contacterListController($scope, contacterService,confirmDialogCtrl,ngDialog) {
    var contacterController = this;
    contacterController.addNewContacter = function () {
        var newContacter = { Id: -1, Name: "", Telephones: "", CustomerId: contacterController.customer.Id };
        $scope.contacter = newContacter;
        var newContacterInstance = ngDialog.openConfirm({
            template: "/../App_Client/Components/Contacter/eachContacterEdit.html",
            controller: "eachContacterEditController",
            controllerAs: "ecec",
            scope: $scope,
            closeByDocument: false,
            showClose: false
        });
        newContacterInstance.then(function successCallback(responsedContacter) {
            contacterController.contacters.push(responsedContacter);
        });
        //contacterService.AddContacter(contacterController.customer.Id, newContacter)
        //                .then(
        //                    function successCallback(response) {
        //                        contacterController.contacters.push(response.data);
        //                    },
        //                    function failCallback(response) {
        //                        confirmDialogCtrl.ConfirmDialog("创建新的联系人失败");
        //                    }
        //                );
    };
    contacterController.deleteContacter = function (c) {
        var index = contacterController.contacters.indexOf(c);
        if (index >= 0) {
            var ngDialogInstance = confirmDialogCtrl.DeleteConfirmDialog("确定要删除选择的联系人吗？");
            ngDialogInstance.then(function () {
                contacterService.deleteContacter(contacterController.customer.Id,c.Id)
                                .then(
                                    function successCallback(response) {
                                        contacterController.contacters.splice(index, 1);
                                    },
                                    function failCallback(response) {
                                        confirmDialogCtrl.ConfirmDialog("删除联系人失败");
                                    }
                                )
            });
        }
        else {
            confirmDialogCtrl.ConfirmDialog("删除联系人失败，请刷新页面重试");
        }
    };

};

angular.module("ERPApp")
        .component("contacterList", {
            templateUrl: "/../App_Client/Components/Contacter/contacterList.html",
            controller: contacterListController,
            controllerAs: "contacterController",
            bindings: {
                contacters: "=contacters",
                customer:"="
            }
        });


