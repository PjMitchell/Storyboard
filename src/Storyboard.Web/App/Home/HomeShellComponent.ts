import {Component} from 'angular2/core';
import {RouteConfig, RouterOutlet} from 'angular2/router';
import {SummaryComponent} from './components/summarycomponent';
import {CreateStoryComponent} from './components/createstorycomponent';
import {CreateActorComponent} from './components/createactorcomponent';
import {StoryOverviewController} from './components/storyoverviewcomponent';
import {ActorOverviewController} from './components/actoroverviewcomponent';
@Component({
    selector: 'app-home',
    template: '<router-outlet></router-outlet>',
    directives: [RouterOutlet]
})
@RouteConfig([
        { path: '/', name: 'Summary', component: SummaryComponent, useAsDefault: true },
        { path: '/CreateStory', name: 'CreateStory', component: CreateStoryComponent },
        { path: '/Story/:storyId/CreateActor', name: 'CreateActor', component: CreateActorComponent },
        { path: '/StoryOverview/:id', name: 'StoryOverview', component: StoryOverviewController },
        { path: '/Story/:storyId/ActorOverview/:id', name: 'ActorOverview', component: ActorOverviewController },
])  
export class HomeShellComponent {
}
