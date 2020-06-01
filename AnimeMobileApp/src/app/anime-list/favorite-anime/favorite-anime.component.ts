import { Component, OnInit } from '@angular/core';
import { Anime } from '~/app/models/anime';
import { RouterExtensions } from 'nativescript-angular/router';
import { AnimeService } from '~/app/services/animeService';
import { RadSideDrawer } from 'nativescript-ui-sidedrawer';
import * as app from "tns-core-modules/application";
import { UserService } from '~/app/services/userService';
import { User } from '~/app/models/user';

@Component({
	moduleId: module.id,
	selector: 'favorite-anime',
	templateUrl: './favorite-anime.component.html',
	styleUrls: ['./favorite-anime.component.scss']
})

export class FavoriteAnimeComponent implements OnInit {

	activeUser: User;
	animes: Array<Anime>;

	constructor(private routerExtensions: RouterExtensions,
		private animeService: AnimeService,
		private userServie: UserService) { }

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
		return 'auto'.repeat(Math.ceil(this.animes.length / 2));
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

	getActiveUser() {
		this.userServie.activeUser$.subscribe(user => {
			this.activeUser = user;
			this.animes.filter(manga => this.activeUser.favoritesMangaIds.indexOf(manga.id) > 1);
		});
	}
}