import { Component, OnInit } from '@angular/core';
import { RadSideDrawer } from 'nativescript-ui-sidedrawer';
import * as app from "tns-core-modules/application";

@Component({
	moduleId: module.id,
	selector: 'anime-list',
	templateUrl: './anime-list.component.html',
	styleUrls: ['./anime-list.component.scss']
})

export class AnimeListComponent implements OnInit {

	constructor() { }

	ngOnInit() { }
	
    onDrawerButtonTap(): void {
        const sideDrawer = <RadSideDrawer>app.getRootView();
        sideDrawer.showDrawer();
    }
}