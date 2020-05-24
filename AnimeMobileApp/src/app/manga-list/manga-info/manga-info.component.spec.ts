import { TestBed, inject } from '@angular/core/testing';

import { MangaInfoComponent } from './manga-info.component';

describe('a manga-info component', () => {
	let component: MangaInfoComponent;

	// register all needed dependencies
	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [
				MangaInfoComponent
			]
		});
	});

	// instantiation through framework injection
	beforeEach(inject([MangaInfoComponent], (MangaInfoComponent) => {
		component = MangaInfoComponent;
	}));

	it('should have an instance', () => {
		expect(component).toBeDefined();
	});
});