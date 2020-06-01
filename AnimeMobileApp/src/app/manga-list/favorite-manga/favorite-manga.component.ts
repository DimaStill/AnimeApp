import { Component, OnInit } from '@angular/core';
import { Manga } from '~/app/models/manga';
import { RouterExtensions } from 'nativescript-angular/router';
import { MangaService } from '~/app/services/mangaService';
import { RadSideDrawer } from 'nativescript-ui-sidedrawer';
import * as app from "tns-core-modules/application";
import { UserService } from '~/app/services/userService';
import { User } from '~/app/models/user';

@Component({
	moduleId: module.id,
	selector: 'favorite-manga',
	templateUrl: './favorite-manga.component.html',
	styleUrls: ['./favorite-manga.component.scss']
})

export class FavoriteMangaComponent implements OnInit {
	mangas: Array<Manga>;
	activeUser: User;

	constructor(private routerExtensions: RouterExtensions,
		private mangaService: MangaService,
		private userServie: UserService) { }

	ngOnInit() { 
		this.getActiveUser();
		this.getAllMangas();
	}
	
    onDrawerButtonTap(): void {
        const sideDrawer = <RadSideDrawer>app.getRootView();
        sideDrawer.showDrawer();
	}

	getAllMangas() {
		this.mangaService.getAllMangas().subscribe(manga => {
			this.mangas = manga;
		});
	}
	
	getCountRows() {
		return 'auto'.repeat(Math.ceil(this.mangas.length / 2));
	}

	getRow(index: number) {
		return Math.floor(index / 2);
	}

	getCol(index: number) {
		return index % 2;
	}
	
	selectManga(manga: Manga) {
		this.mangaService.setActiveManga(manga);
		this.routerExtensions.navigate(['/manga-info'], { clearHistory: false });
	}

	getActiveUser() {
		this.userServie.activeUser$.subscribe(user => {
			this.activeUser = user;
			this.mangas.filter(manga => this.activeUser.favoritesMangaIds.indexOf(manga.id) > 1);
		});
	}
}