import { Component, OnInit } from '@angular/core';
import { Anime } from '~/app/models/anime';
import { RouterExtensions } from 'nativescript-angular/router';
import { AnimeService } from '~/app/services/animeService';
import { RadSideDrawer } from 'nativescript-ui-sidedrawer';
import * as app from "tns-core-modules/application";
import * as moment from 'moment';

@Component({
	moduleId: module.id,
	selector: 'announcements',
	templateUrl: './announcements.component.html',
	styleUrls: ['./announcements.component.scss']
})

export class AnnouncementsComponent implements OnInit {
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
		this.animeService.getAllAnime().subscribe(animes => {
			this.animes = animes.filter(anime => {
				console.log(moment(anime.releaseDate).format('ddd.MM.yyyy'));
				console.log(moment(new Date()));
				console.log(moment(anime.releaseDate).isAfter(new Date()))
				return moment(anime.releaseDate, 'dd.MM.yyyy').isAfter(new Date());
			});
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
}