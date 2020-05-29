import { Component, OnInit } from '@angular/core';
import { RadSideDrawer } from 'nativescript-ui-sidedrawer';
import * as app from "tns-core-modules/application";
import { Manga } from '../models/manga';
import { RouterExtensions } from 'nativescript-angular/router';
import { MangaService } from '../services/mangaService';

@Component({
	moduleId: module.id,
	selector: 'manga-list',
	templateUrl: './manga-list.component.html',
	styleUrls: ['./manga-list.component.scss']
})

export class MangaListComponent implements OnInit {
	mangas: Array<Manga>;

	constructor(private routerExtensions: RouterExtensions,
		private mangaService: MangaService) { }

	ngOnInit() { 
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
		this.routerExtensions.navigate(['/manga-info'], { clearHistory: true });
	}
}