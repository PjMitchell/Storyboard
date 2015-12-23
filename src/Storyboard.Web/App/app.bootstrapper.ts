import {bootstrap}    from 'angular2/platform/browser';
import {HomeShellComponent} from './home/homeshellcomponent';
import {ROUTER_PROVIDERS}  from 'angular2/router';  

bootstrap(HomeShellComponent, [ROUTER_PROVIDERS]);
