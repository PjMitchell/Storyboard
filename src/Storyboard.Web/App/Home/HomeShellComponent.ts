import {Component} from 'angular2/core';
import {RouteConfig, RouterOutlet} from 'angular2/router';
import {SummaryComponent} from './components/summarycomponent';

@Component({
    selector: 'app-home',
    template: '<router-outlet></router-outlet>',
    directives: [RouterOutlet]
})
@RouteConfig([
    { path: '/', name: 'Summary', component: SummaryComponent, useAsDefault: true }
])  
export class HomeShellComponent {
}
