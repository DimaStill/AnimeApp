import { Component, OnInit } from '@angular/core';

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
}