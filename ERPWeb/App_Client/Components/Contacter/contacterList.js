function contacterListController($scope, contacterService) {
    var contacterController = this;
    contacterController.addNewContacter = function () {
        var newContacter = { Id: -1, Name: "", Telephones: "" };
        contacterService.AddContacter(contacterController.customer.Id, newContacter)
                        .then(
                            function successCallback(response) {
                                contacterController.contacters.push(response.data);
                            },
                            function failCallback(response){
                                alert("Failed to create new contacter");
                            }
                        );
    };
    contacterController.deleteContacter = function (c) {
        var index = contacterController.contacters.indexOf(c);
        if (index >= 0) {
            contacterService.deleteContacter(c.Id, contacterController.customer.Id)
                            .then(
                                function successCallback(response) {
                                    contacterController.contacters.splice(index, 1);
                                },
                                function failCallback(response) {
                                    alert("delete contacter error, server side");
                                }
                            )
        }
        else {
            alert("delete contacter error,client side");
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


