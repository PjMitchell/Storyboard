import {bootstrap}    from 'angular2/platform/browser';
import {ROUTER_PROVIDERS}  from 'angular2/router';
import {HttpAdaptor} from './core/httpadaptor';
import {HomeShellComponent} from './home/homeshellcomponent';
import {StoryOverviewDataService} from './home/services/storyoverviewdataservice';
bootstrap(HomeShellComponent, [ROUTER_PROVIDERS, HttpAdaptor, StoryOverviewDataService]);
