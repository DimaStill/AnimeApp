import { Component, OnInit } from '@angular/core';
import { RadSideDrawer } from 'nativescript-ui-sidedrawer';
import * as app from "tns-core-modules/application";
import { RouterExtensions } from 'nativescript-angular/router';
import { AnimeService } from '~/app/services/animeService';
import { Anime } from '~/app/models/anime';
import { UserService } from '~/app/services/userService';
import { User } from '~/app/models/user';
import { GenreService } from '~/app/services/genreService';
import { Genre } from '~/app/models/genre';
import { StudioService } from '~/app/services/studioService';
import { Studio } from '~/app/models/studio';

@Component({
	moduleId: module.id,
	selector: 'anime-info',
	templateUrl: './anime-info.component.html',
	styleUrls: ['./anime-info.component.scss']
})

export class AnimeInfoComponent implements OnInit {

	anime: Anime;
	activeUser: User;
	genres = new Array<Genre>();
	studios = new Array<Studio>();

	constructor(private animeService: AnimeService,
		private userService: UserService,
		private genreService: GenreService,
		private studioService: StudioService) { }

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
			this.getGenres();
		});
	}

	addFavorite() {
		if (!this.activeUser.favoritesAnimeIds) {
			this.activeUser.favoritesAnimeIds = new Array<number>();
		}
		
		const index = this.activeUser.favoritesAnimeIds.indexOf(this.anime.id);
		if (index === -1) {
			this.activeUser.favoritesAnimeIds.push(this.anime.id);
		}
		this.userService.putUser(this.activeUser, this.activeUser.id).subscribe(user => {
			this.userService.activeUser$.next(user);
		});
	}

	removeFavorite() {
		const index = this.activeUser.favoritesAnimeIds.indexOf(this.anime.id);
		if (index !== -1) { 
			this.activeUser.favoritesAnimeIds.splice(index, 1);
		}
		
		this.userService.putUser(this.activeUser.favoritesAnimeIds, this.activeUser.id).subscribe(user => {
			this.userService.activeUser$.next(user);
		});
	}

	getActiveUser() {
		this.userService.activeUser$.subscribe(user => {
			this.activeUser = user;
		});
	}

	isFavorite() {
		return this.activeUser.favoritesAnimeIds && this.activeUser.favoritesAnimeIds.some(favoriteId => {
			return this.anime.id === favoriteId;
		});
	}
	
	getGenres() {
		this.anime.genreIds.forEach(genreId => {
			this.genreService.getGenre(genreId).subscribe(genre => {
				this.genres.push(genre);
			});
		});
	}

	getVoices() {
		this.anime.voiceIds.forEach(voiceId => {
			this.studioService.getStudio(voiceId).subscribe(voice => {
				this.studios.push(voice);
			});
		});
	}
}