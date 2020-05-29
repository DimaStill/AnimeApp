import { Component, OnInit } from '@angular/core';
import { Manga } from '~/app/models/manga';
import { User } from '~/app/models/user';
import { MangaService } from '~/app/services/mangaService';
import { UserService } from '~/app/services/userService';
import { RadSideDrawer } from 'nativescript-ui-sidedrawer';
import * as app from "tns-core-modules/application";

@Component({
	moduleId: module.id,
	selector: 'manga-info',
	templateUrl: './manga-info.component.html',
	styleUrls: ['./manga-info.component.scss']
})

export class MangaInfoComponent implements OnInit {

	manga: Manga;
	activeUser: User;

	constructor(private mangaService: MangaService,
		private userService: UserService) { }

	ngOnInit() {
		this.getActiveManga();
		this.getActiveUser();
	}

	onDrawerButtonTap(): void {
		const sideDrawer = <RadSideDrawer>app.getRootView();
		sideDrawer.showDrawer();
	}

	getActiveManga() {
		this.mangaService.activeManga$.subscribe(manga => {
			this.manga = manga;
		});
	}

	addFavorite() {
		if (!this.activeUser.favoritesMangas) {
			this.activeUser.favoritesMangas = new Array<Manga>();
		}
		this.activeUser.favoritesMangas.push(this.manga);
		this.userService.putUser(this.activeUser, this.activeUser.id).subscribe(user => {
			this.userService.activeUser$.next(user);
		});
	}

	removeFavorite() {
		const index = this.activeUser.favoritesMangas.indexOf(this.manga);
		if (index !== -1) { 
			this.activeUser.favoritesMangas.splice(index, 1);
		}
		const idFavoriteManga = {
			favoritesMangas: this.activeUser.favoritesMangas
		}
		this.userService.putUser(idFavoriteManga, this.activeUser.id).subscribe(user => {
			this.userService.activeUser$.next(user);
		});
	}

	getActiveUser() {
		this.userService.activeUser$.subscribe(user => {
			this.activeUser = user;
		});
	}

	isFavorite() {
		return this.activeUser.favoritesMangas && this.activeUser.favoritesMangas.some(favorite => {
			this.manga.id === favorite.id;
		});
	}
}