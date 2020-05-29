import { Component, OnInit } from '@angular/core';
import { RadSideDrawer } from 'nativescript-ui-sidedrawer';
import * as app from "tns-core-modules/application";
import { RouterExtensions } from 'nativescript-angular/router';
import { AnimeService } from '~/app/services/animeService';
import { Anime } from '~/app/models/anime';
import { UserService } from '~/app/services/userService';
import { User } from '~/app/models/user';

@Component({
	moduleId: module.id,
	selector: 'anime-info',
	templateUrl: './anime-info.component.html',
	styleUrls: ['./anime-info.component.scss']
})

export class AnimeInfoComponent implements OnInit {

	anime: Anime;
	activeUser: User;

	constructor(private animeService: AnimeService,
		private userService: UserService) { }

	ngOnInit() {
		this.getActiveAnime();
		this.getActiveUser();
	}

	onDrawerButtonTap(): void {
		const sideDrawer = <RadSideDrawer>app.getRootView();
		sideDrawer.showDrawer();
	}

	getActiveAnime() {
		this.animeService.activeUser$.subscribe(anime => {
			this.anime = anime;
		});
	}

	addFavorite() {
		if (!this.activeUser.favoritesAnimes) {
			this.activeUser.favoritesAnimes = new Array<Anime>();
		}
		this.activeUser.favoritesAnimes.push(this.anime);
		this.userService.putUser(this.activeUser, this.activeUser.id).subscribe(user => {
			this.userService.activeUser$.next(user);
		});
	}

	removeFavorite() {
		const index = this.activeUser.favoritesAnimes.indexOf(this.anime);
		if (index !== -1) { 
			this.activeUser.favoritesAnimes.splice(index, 1);
		}
		const idFavoriteAnime = {
			favoritesAnimes: this.activeUser.favoritesAnimes
		}
		this.userService.putUser(idFavoriteAnime, this.activeUser.id).subscribe(user => {
			this.userService.activeUser$.next(user);
		});
	}

	getActiveUser() {
		this.userService.activeUser$.subscribe(user => {
			this.activeUser = user;
		});
	}

	isFavorite() {
		return this.activeUser.favoritesAnimes && this.activeUser.favoritesAnimes.some(favorite => {
			this.anime.id === favorite.id;
		});
	}
}