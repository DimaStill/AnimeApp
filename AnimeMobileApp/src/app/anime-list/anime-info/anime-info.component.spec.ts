import { TestBed, inject } from '@angular/core/testing';

import { AnimeInfoComponent } from './anime-info.component';

describe('a anime-info component', () => {
	let component: AnimeInfoComponent;

	// register all needed dependencies
	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [
				AnimeInfoComponent
			]
		});
	});

	// instantiation through framework injection
	beforeEach(inject([AnimeInfoComponent], (AnimeInfoComponent) => {
		component = AnimeInfoComponent;
	}));

	it('should have an instance', () => {
		expect(component).toBeDefined();
	});
});