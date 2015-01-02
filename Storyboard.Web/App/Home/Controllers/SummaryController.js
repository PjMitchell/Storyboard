/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
var Home;
(function (Home) {
    var SummaryController = (function () {
        function SummaryController($modal, StoryOverviewDataService) {
            var _this = this;
            this.onNewStory = function () {
                _this.getAllSummaries();
            };
            this.dataService = StoryOverviewDataService;
            this.modalService = $modal;
            this.Summaries = [];
            this.getAllSummaries = function () {
                _this.dataService.getAll().success(_this.onSummariesReturned);
            };
            this.onSummariesReturned = function (result) {
                _this.Summaries = result;
            };
            this.getAllSummaries();
        }
        SummaryController.prototype.deleteStoryCommand = function (id) {
            this.dataService.delete(id).success(this.getAllSummaries);
        };
        SummaryController.prototype.openCreateStoryDialog = function () {
            var settings = {
                controller: 'CreateStoryDialogController',
                controllerAs: 'vm',
                templateUrl: 'App/Home/Views/CreateStoryDialogView.html'
            };
            this.modalService.open(settings).result.then(this.onNewStory);
        };
        SummaryController.$inject = ['$modal', 'StoryOverviewDataService'];
        return SummaryController;
    })();
    Home.SummaryController = SummaryController;
})(Home || (Home = {}));
//# sourceMappingURL=SummaryController.js.map