import { Component, OnInit } from '@angular/core';
import { RadSideDrawer } from 'nativescript-ui-sidedrawer';
import * as app from "tns-core-modules/application";

@Component({
	moduleId: module.id,
	selector: 'anime-info',
	templateUrl: './anime-info.component.html',
	styleUrls: ['./anime-info.component.scss']
})

export class AnimeInfoComponent implements OnInit {

	constructor() { }

	ngOnInit() { }

    onDrawerButtonTap(): void {
        const sideDrawer = <RadSideDrawer>app.getRootView();
        sideDrawer.showDrawer();
    }
}