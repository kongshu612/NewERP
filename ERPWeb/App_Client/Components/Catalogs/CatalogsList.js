function catalogsListController( CRUDService,confirmDialogCtrl) {
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
                confirmDialogCtrl.ConfirmDialog("添加客户类型失败");
            ac = null;
        });
    };
    cl.deleteCatalog = function (catalog) {
        var index = cl.catalogsList.indexOf(catalog);
        if (index >= 0) {
            var ngDialogInstance = confirmDialogCtrl.DeleteConfirmDialog("确定要删除选择的类别吗？");
            ngDialogInstance.then(function () {
                CRUDService.delete("/api/catalogs/" + catalog.Id)
                    .then(
                        function successCallback(response) {
                            cl.catalogsList.splice(index, 1);
                        },
                        function failCallback(response) {
                            confirmDialogCtrl.ConfirmDialog("删除客户类型失败");
                        }
                    );
            });
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