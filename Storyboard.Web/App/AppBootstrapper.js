/// <reference path="home/HomeModule.ts" />
/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="home/overviewcontroller.ts" />
/// <reference path="../scripts/typings/angularjs/angular-route.d.ts" />
var app = angular.module('storyboardApp', ['ngRoute']);
app.factory('StoryOverviewDataService', function ($http) {
    return new Home.StoryOverviewDataService($http);
});
app.controller('OverviewController', Home.OverviewController);
app.config(function ($routeProvider) {
    $routeProvider.when('/', {
        controller: 'OverviewController',
        controllerAs: 'vm',
        templateUrl: 'App/Home/Views/OverviewShellView.html'
    }).otherwise({ redirectTo: '/' });
});
//# sourceMappingURL=AppBootstrapper.js.map
