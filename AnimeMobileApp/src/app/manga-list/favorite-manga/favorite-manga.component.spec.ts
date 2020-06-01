import { TestBed, inject } from '@angular/core/testing';

import { FavoriteMangaComponent } from './favorite-manga.component';

describe('a favorite-manga component', () => {
	let component: FavoriteMangaComponent;

	// register all needed dependencies
	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [
				FavoriteMangaComponent
			]
		});
	});

	// instantiation through framework injection
	beforeEach(inject([FavoriteMangaComponent], (FavoriteMangaComponent) => {
		component = FavoriteMangaComponent;
	}));

	it('should have an instance', () => {
		expect(component).toBeDefined();
	});
});