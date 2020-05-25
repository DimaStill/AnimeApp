import { Component, OnInit } from '@angular/core';
import { RadSideDrawer } from 'nativescript-ui-sidedrawer';
import * as app from "tns-core-modules/application";

@Component({
	moduleId: module.id,
	selector: 'manga-list',
	templateUrl: './manga-list.component.html',
	styleUrls: ['./manga-list.component.scss']
})

export class MangaListComponent implements OnInit {

	constructor() { }

	ngOnInit() { }
	
    onDrawerButtonTap(): void {
        const sideDrawer = <RadSideDrawer>app.getRootView();
        sideDrawer.showDrawer();
    }
}