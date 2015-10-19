/// <reference path="typings/angularjs/angular.d.ts" />
/// <reference path="typings/angularjs/angular-route.d.ts" />
/// <reference path="home/services/actordataservice.ts" />
/// <reference path="home/services/linkdataservice.ts" />
/// <reference path="home/services/storyoverviewdataservice.ts" />
/// <reference path="home/directives/editfield.ts" />
/// <reference path="home/controllers/actoroverviewcontroller.ts" />
/// <reference path="home/controllers/createactordialogcontroller.ts" />
/// <reference path="home/controllers/createstorydialogcontroller.ts" />
/// <reference path="home/controllers/storyoverviewcontroller.ts" />
/// <reference path="home/controllers/summarycontroller.ts" />
var app = angular.module('storyboardApp', ['ngRoute', 'ui.bootstrap']);
app.factory('StoryOverviewDataService', function ($http) { return new Home.StoryOverviewDataService($http); });
app.factory('ActorDataService', function ($http) { return new Home.ActorDataService($http); });
app.factory('LinkDataService', function ($http) { return new Home.LinkDataService($http); });
app.controller('EditController', function ($scope) { return new Home.EditController($scope); });
app.directive('sbEditTitle', function () { return new Home.EditTitle(); });
app.directive('sbEditArea', function () { return new Home.EditArea(); });
app.directive('sbSidebar', function () { return new Home.SideBar(); });
app.controller('SummaryController', Home.SummaryController);
app.controller('CreateStoryDialogController', Home.CreateStoryDialogController);
app.controller('StoryOverviewController', Home.StoryOverviewController);
app.controller('ActorOverviewController', Home.ActorOverviewController);
app.controller('CreateActorDialogController', Home.CreateActorDialogController);
app.config(function ($routeProvider) {
    $routeProvider.when('/', {
        controller: 'SummaryController',
        controllerAs: 'vm',
        templateUrl: '/Templates/SummaryShellView.html'
    })
        .when('/story/add', {
        controller: 'AddStoryController',
        controllerAs: 'vm',
        templateUrl: '/Templates/AddStoryShellView.html'
    })
        .when('/story/:id', {
        controller: 'StoryOverviewController',
        controllerAs: 'vm',
        templateUrl: '/Templates/StoryOverviewShellView.html'
    })
        .when('/actor/:id/s/:storyId', {
        controller: 'ActorOverviewController',
        controllerAs: 'vm',
        templateUrl: '/Templates/ActorOverviewShellView.html'
    })
        .otherwise({ redirectTo: '/' });
});
