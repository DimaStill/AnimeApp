import { TestBed, inject } from '@angular/core/testing';

import { AnnouncementsComponent } from './announcements.component';

describe('a announcements component', () => {
	let component: AnnouncementsComponent;

	// register all needed dependencies
	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [
				AnnouncementsComponent
			]
		});
	});

	// instantiation through framework injection
	beforeEach(inject([AnnouncementsComponent], (AnnouncementsComponent) => {
		component = AnnouncementsComponent;
	}));

	it('should have an instance', () => {
		expect(component).toBeDefined();
	});
});