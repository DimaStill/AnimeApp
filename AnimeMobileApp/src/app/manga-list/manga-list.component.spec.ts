import { TestBed, inject } from '@angular/core/testing';

import { MangaListComponent } from './manga-list.component';

describe('a manga-list component', () => {
	let component: MangaListComponent;

	// register all needed dependencies
	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [
				MangaListComponent
			]
		});
	});

	// instantiation through framework injection
	beforeEach(inject([MangaListComponent], (MangaListComponent) => {
		component = MangaListComponent;
	}));

	it('should have an instance', () => {
		expect(component).toBeDefined();
	});
});