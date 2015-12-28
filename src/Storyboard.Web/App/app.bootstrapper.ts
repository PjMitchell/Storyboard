import {bootstrap}    from 'angular2/platform/browser';
import {ROUTER_PROVIDERS}  from 'angular2/router';
import {HttpAdaptor} from './core/httpadaptor';
import {HomeShellComponent} from './home/homeshellcomponent';
import {OverviewDataService} from './home/services/overviewdataservice';
import {StoryDataService} from './home/services/storydataservice';
import {ActorDataService} from './home/services/actordataservice';

bootstrap(HomeShellComponent, [ROUTER_PROVIDERS, HttpAdaptor, OverviewDataService, StoryDataService, ActorDataService]);
