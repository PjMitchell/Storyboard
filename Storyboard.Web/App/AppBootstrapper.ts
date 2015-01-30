/// <reference path="home/HomeModule.ts" />
/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="home/Controllers/SummaryController.ts" />
/// <reference path="../scripts/typings/angularjs/angular-route.d.ts" />

var app = angular.module('storyboardApp', ['ngRoute','ui.bootstrap']);
app.factory('StoryOverviewDataService', ($http: ng.IHttpService) => new Home.StoryOverviewDataService($http));
app.factory('ActorDataService', ($http: ng.IHttpService) => new Home.ActorDataService($http));
app.factory('LinkDataService', ($http: ng.IHttpService) => new Home.LinkDataService($http));
app.directive('sbEditfield', () => new Home.EditField());
app.controller('SummaryController', Home.SummaryController);
app.controller('CreateStoryDialogController', Home.CreateStoryDialogController);
app.controller('StoryOverviewController', Home.StoryOverviewController);
app.controller('CreateActorDialogController', Home.CreateActorDialogController);


app.config(function ($routeProvider : ng.route.IRouteProvider) {
    $routeProvider.when('/', {
        controller: 'SummaryController',
        controllerAs: 'vm',
        templateUrl: 'App/Home/Views/SummaryShellView.html'
    })
        .when('/story/add', {
            controller: 'AddStoryController',
            controllerAs: 'vm',
            templateUrl: 'App/Home/Views/AddStoryShellView.html'
        })
        .when('/story/:id', {
            controller: 'StoryOverviewController',
            controllerAs: 'vm',
            templateUrl: 'App/Home/Views/OverviewShellView.html'
        })
        .otherwise({ redirectTo: '/' });
});