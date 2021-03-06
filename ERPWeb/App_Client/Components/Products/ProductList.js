﻿

function ProductListController($scope, CRUDService, $uibModal,confirmDialogCtrl,ngDialog) {
    pc = this;
    pc.list = [];
    pc.ready = false;
    pc.error = false;    
    pc.onLoad = function () {
        pc.error = false;
        pc.ready = false;
        pc.list = [];
        CRUDService.Load("/api/products")
                    .then(
                    function (response) {
                        pc.list = response.data;
                        pc.ready = true;
                    },
                    function failCallback(response) {
                        pc.error = true;
                    }
                    );
    };
    pc.deleteProduct = function (product) {
        console.log("delte");
        var index = this.list.indexOf(product);
        if (index >= 0) {
            var ngDialogInstance = confirmDialogCtrl.DeleteConfirmDialog("确定要删除选择的产品吗？");
            ngDialogInstance.then(function () {
                CRUDService.delete("/api/Products/" + product.Id)
                .then(
                    function successCallback(response) {
                        pc.list.splice(index, 1);
                    }, function failCallback(response) {
                        confirmDialogCtrl.ConfirmDialog("删除产品信息失败");
                    }
                );
            });
        }
    };
    this.AddProduct = function () {
        newProduct = {
            Id: -1,
            Name: '',
            Size: 0,
            Count: 0
        };
        //function productAddedDialog($uibModalInstance, newProduct) {
        //    var Ctrl = this;
        //    Ctrl.newProduct = newProduct;
        //    Ctrl.Save = function () {
        //    };
        //    Ctrl.Cancel = function () { };
        //};
        //$uibModal.open(
        //    {
        //        backdrop: 'static',
        //        template: `
        //            `,
        //        controller: productAddedDialog,
        //        controllerAs:'newProductCtrl'
        //    });
        CRUDService.add("/api/Products",newProduct)
                .then(
                    function successCallback(response) {
                        pc.list.push(response.data);
                    },
                    function failCallback(response) {
                        alert("添加失败" + response.status);
                    }
                );
    };
    pc.$onInit = function () {
        pc.onLoad();
    };
}

angular.module('ERPApp')
    .controller("ProductListController", ProductListController)
    .component('productList', {
    templateUrl: '/../App_Client/Components/Products/ProductList.html',
    controller: ProductListController
});