import { Component, OnInit } from '@angular/core';
import { RadSideDrawer } from 'nativescript-ui-sidedrawer';
import * as app from "tns-core-modules/application";
import { AnimeService } from '../services/animeService';
import { Anime } from '../models/anime';
import { RouterExtensions } from 'nativescript-angular/router';

@Component({
	moduleId: module.id,
	selector: 'anime-list',
	templateUrl: './anime-list.component.html',
	styleUrls: ['./anime-list.component.scss']
})

export class AnimeListComponent implements OnInit {
	animes: Array<Anime>;

	constructor(private routerExtensions: RouterExtensions,
		private animeService: AnimeService) { }

	ngOnInit() { 
		this.getAllAnime();
	}
	
    onDrawerButtonTap(): void {
        const sideDrawer = <RadSideDrawer>app.getRootView();
        sideDrawer.showDrawer();
	}

	getAllAnime() {
		this.animeService.getAllAnime().subscribe(anime => {
			this.animes = anime;
		});
	}
	
	getCountRows() {
		return 'auto, '.repeat(Math.ceil(this.animes.length / 2));
	}

	getRow(index: number) {
		return Math.floor(index / 2);
	}

	getCol(index: number) {
		return index % 2;
	}
	
	selectAnime(anime: Anime) {
		this.animeService.setActiveAnime(anime);
		this.routerExtensions.navigate(['/anime-info'], { clearHistory: false });
	}
}