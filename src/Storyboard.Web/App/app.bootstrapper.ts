import {bootstrap}    from 'angular2/platform/browser';
import {ROUTER_PROVIDERS}  from 'angular2/router';
import {HttpAdaptor} from './Core/HttpAdaptor';
import {HomeShellComponent} from './home/homeshellcomponent';
//import {StoryOverviewDataService} from './Home/Services/StoryOverviewDataService';
bootstrap(HomeShellComponent, [ROUTER_PROVIDERS, HttpAdaptor]);
