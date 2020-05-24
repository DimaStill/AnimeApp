import { TestBed, inject } from '@angular/core/testing';

import { UserIdentificationComponent } from './user-identification.component';

describe('a user-identification component', () => {
	let component: UserIdentificationComponent;

	// register all needed dependencies
	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [
				UserIdentificationComponent
			]
		});
	});

	// instantiation through framework injection
	beforeEach(inject([UserIdentificationComponent], (UserIdentificationComponent) => {
		component = UserIdentificationComponent;
	}));

	it('should have an instance', () => {
		expect(component).toBeDefined();
	});
});