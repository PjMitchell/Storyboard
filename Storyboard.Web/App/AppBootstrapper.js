/// <reference path="home/HomeModule.ts" />
/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="home/Controllers/SummaryController.ts" />
/// <reference path="../scripts/typings/angularjs/angular-route.d.ts" />
var app = angular.module('storyboardApp', ['ngRoute', 'ui.bootstrap']);
app.factory('StoryOverviewDataService', function ($http) { return new Home.StoryOverviewDataService($http); });
app.factory('ActorDataService', function ($http) { return new Home.ActorDataService($http); });
app.factory('LinkDataService', function ($http) { return new Home.LinkDataService($http); });
app.controller('EditController', function ($scope) { return new Home.EditController($scope); });
app.directive('sbEditTitle', function () { return new Home.EditTitle(); });
app.directive('sbEditArea', function () { return new Home.EditArea(); });
app.controller('SummaryController', Home.SummaryController);
app.controller('CreateStoryDialogController', Home.CreateStoryDialogController);
app.controller('StoryOverviewController', Home.StoryOverviewController);
app.controller('ActorOverviewController', Home.ActorOverviewController);
app.controller('CreateActorDialogController', Home.CreateActorDialogController);
app.config(function ($routeProvider) {
    $routeProvider.when('/', {
        controller: 'SummaryController',
        controllerAs: 'vm',
        templateUrl: '/App/Home/Views/SummaryShellView.html'
    }).when('/story/add', {
        controller: 'AddStoryController',
        controllerAs: 'vm',
        templateUrl: '/App/Home/Views/AddStoryShellView.html'
    }).when('/story/:id', {
        controller: 'StoryOverviewController',
        controllerAs: 'vm',
        templateUrl: '/App/Home/Views/StoryOverviewShellView.html'
    }).when('/actor/:id/s/:storyId', {
        controller: 'ActorOverviewController',
        controllerAs: 'vm',
        templateUrl: '/App/Home/Views/ActorOverviewShellView.html'
    }).otherwise({ redirectTo: '/' });
});
//# sourceMappingURL=AppBootstrapper.js.map