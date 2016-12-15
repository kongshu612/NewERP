describe("Hellworld Testing", function () {
    beforeEach(module("ERPApp"));
    var inController, scope;
    beforeEach(inject(function($controller){
        scope={test:"test"};
        inController = $controller("orderList",{$scope:scope});
    }));
    it("my first Testing", function () {
        scope = { test: "test" };
        scope.test = "yes";
        expect(scope.test).toEqual("yes");
        expect(scope.test).not.toEqual("test");
    });
});