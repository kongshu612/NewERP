function catalogsListController( CRUDService) {
    var cl = this;
    cl.catalogsList = [];
    cl.ready = false;
    cl.error = false;
    cl.addCatalog = function () {
        ac = {
            Id: -1,
            Name: "",
            Description: ""
        };
        CRUDService.add("/api/catalogs",ac)
            .then(function successCallback(response) {
            ac = response.data;
            cl.catalogsList.push(ac);
        }, function failCallback(response) {
            alert("error occur");
            ac = null;
        });
    };
    cl.deleteCatalog = function (catalog) {
        var index = cl.catalogsList.indexOf(catalog);
        if (index >= 0) {
            CRUDService.delete("/api/catalogs/"+catalog.Id)
                .then(
                    function successCallback(response) {
                        cl.catalogsList.splice(index, 1);
                    },
                    function failCallback(response) {
                        alert("delete eror");
                    }
                );
        }
    };
    cl.reflesh = function () {
        cl.ready = false;
        cl.error = false;
        cl.catalogsList = [];
        cl.onLoad();
    };
    cl.onLoad = function () {
        CRUDService.Load("/api/catalogs")
                        .then(
                        function successCallback(response) {
                            cl.ready = true;
                            cl.catalogsList = response.data;
                        },
                        function failCallback(response) {
                            cl.error = true;
                        }
                        );
    };
    cl.$onInit = function () {
        cl.onLoad();
    }
};


angular.module("ERPApp")
        .controller("catalogsListController", catalogsListController)
        .component("catalogsList", {
            templateUrl: "/../App_Client/Components/Catalogs/CatalogsList.html",
            controller: "catalogsListController",
            controllerAs:'cl'
        });