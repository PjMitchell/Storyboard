import {Component, Input} from 'angular2/core';

@Component({
    selector: 'sb-SideBar',
    templateUrl: '/Templates/Home/SidebarTemplate.html',
    inputs: ['Header', 'Width']
})
export class SideBarComponent {
    Header: string;
    Width: string;
}