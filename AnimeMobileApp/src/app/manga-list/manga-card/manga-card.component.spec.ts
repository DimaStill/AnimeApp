import { TestBed, inject } from '@angular/core/testing';

import { MangaCardComponent } from './manga-card.component';

describe('a manga-card component', () => {
	let component: MangaCardComponent;

	// register all needed dependencies
	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [
				MangaCardComponent
			]
		});
	});

	// instantiation through framework injection
	beforeEach(inject([MangaCardComponent], (MangaCardComponent) => {
		component = MangaCardComponent;
	}));

	it('should have an instance', () => {
		expect(component).toBeDefined();
	});
});