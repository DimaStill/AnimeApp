import { TestBed, inject } from '@angular/core/testing';

import { FavoriteAnimeComponent } from './favorite-anime.component';

describe('a favorite-anime component', () => {
	let component: FavoriteAnimeComponent;

	// register all needed dependencies
	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [
				FavoriteAnimeComponent
			]
		});
	});

	// instantiation through framework injection
	beforeEach(inject([FavoriteAnimeComponent], (FavoriteAnimeComponent) => {
		component = FavoriteAnimeComponent;
	}));

	it('should have an instance', () => {
		expect(component).toBeDefined();
	});
});