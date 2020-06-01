import { TestBed, inject } from '@angular/core/testing';

import { AnimeListComponent } from './anime-list.component';

describe('a anime-list component', () => {
	let component: AnimeListComponent;

	// register all needed dependencies
	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [
				AnimeListComponent
			]
		});
	});

	// instantiation through framework injection
	beforeEach(inject([AnimeListComponent], (AnimeListComponent) => {
		component = AnimeListComponent;
	}));

	it('should have an instance', () => {
		expect(component).toBeDefined();
	});
});