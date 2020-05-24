import { Component, OnInit } from '@angular/core';
import { RadSideDrawer } from 'nativescript-ui-sidedrawer';
import * as app from "tns-core-modules/application";

@Component({
	moduleId: module.id,
	selector: 'user-identification',
	templateUrl: './user-identification.component.html',
	styleUrls: ['./user-identification.component.scss']
})

export class UserIdentificationComponent implements OnInit {

	isLoginForm = true;

	constructor() { }

	ngOnInit() { }

	toggleLoginForm() {
		this.isLoginForm = !this.isLoginForm;
	}
	
    onDrawerButtonTap(): void {
        const sideDrawer = <RadSideDrawer>app.getRootView();
        sideDrawer.showDrawer();
    }
}