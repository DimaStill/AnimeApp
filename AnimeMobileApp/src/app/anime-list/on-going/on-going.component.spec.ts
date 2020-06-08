import { TestBed, inject } from '@angular/core/testing';

import { OnGoingComponent } from './on-going.component';

describe('a on-going component', () => {
	let component: OnGoingComponent;

	// register all needed dependencies
	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [
				OnGoingComponent
			]
		});
	});

	// instantiation through framework injection
	beforeEach(inject([OnGoingComponent], (OnGoingComponent) => {
		component = OnGoingComponent;
	}));

	it('should have an instance', () => {
		expect(component).toBeDefined();
	});
});