import { TestBed, inject } from '@angular/core/testing';

import { AnimeCardComponent } from './anime-card.component';

describe('a anime-card component', () => {
	let component: AnimeCardComponent;

	// register all needed dependencies
	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [
				AnimeCardComponent
			]
		});
	});

	// instantiation through framework injection
	beforeEach(inject([AnimeCardComponent], (AnimeCardComponent) => {
		component = AnimeCardComponent;
	}));

	it('should have an instance', () => {
		expect(component).toBeDefined();
	});
});