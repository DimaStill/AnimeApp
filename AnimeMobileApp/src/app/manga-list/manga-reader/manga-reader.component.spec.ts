import { TestBed, inject } from '@angular/core/testing';

import { MangaReaderComponent } from './manga-reader.component';

describe('a manga-reader component', () => {
	let component: MangaReaderComponent;

	// register all needed dependencies
	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [
				MangaReaderComponent
			]
		});
	});

	// instantiation through framework injection
	beforeEach(inject([MangaReaderComponent], (MangaReaderComponent) => {
		component = MangaReaderComponent;
	}));

	it('should have an instance', () => {
		expect(component).toBeDefined();
	});
});