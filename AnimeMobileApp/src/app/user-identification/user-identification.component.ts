import { Component, OnInit } from '@angular/core';
import { RadSideDrawer } from 'nativescript-ui-sidedrawer';
import * as app from "tns-core-modules/application";
import { UserService } from '../services/userService';
import { RouterExtensions } from "nativescript-angular/router";

@Component({
	moduleId: module.id,
	selector: 'user-identification',
	templateUrl: './user-identification.component.html',
	styleUrls: ['./user-identification.component.scss']
})

export class UserIdentificationComponent implements OnInit {

	isLoginForm = true;

	login: string;
	password: string;
	repeatPassword: string;

	constructor(private userService: UserService,
		private routerExtensions: RouterExtensions) { }

	ngOnInit() {
	}

	toggleLoginForm() {
		this.isLoginForm = !this.isLoginForm;
	}
	
    onDrawerButtonTap(): void {
        const sideDrawer = <RadSideDrawer>app.getRootView();
        sideDrawer.showDrawer();
	}
	
	registration(login: string, password: string, repeatPassword: string) {
		if (password === repeatPassword) {
			const newUser = {
				login: login,
				password: password
			}

			this.userService.registration(newUser).subscribe(newUser => {
				if (newUser) {
					this.isLoginForm = true;
				}
			});
		}
	}

	loginUser(login: string, password: string) {
		const user = {
			login: login,
			password: password
		}

		this.userService.loginUser(user).subscribe(user => {
			if (user) {
				this.userService.setActiveUser(user);
				this.routerExtensions.navigate(['/anime-list'], { clearHistory: true });
			}
		});
	}
}