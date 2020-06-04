import { Component, OnInit, Input } from '@angular/core';
import { MangaService } from '~/app/services/mangaService';
import { Anime } from '~/app/models/anime';
import { Manga } from '~/app/models/manga';
import { MangaPages } from '~/app/models/mangaPages';

@Component({
	moduleId: module.id,
	selector: 'manga-reader',
	templateUrl: './manga-reader.component.html',
	styleUrls: ['./manga-reader.component.scss']
})

export class MangaReaderComponent implements OnInit {
	manga: Manga;
	mangaPages: MangaPages;
	currentPage = 0;

	constructor(private mangaService: MangaService) { }

	ngOnInit() {
		console.log('TEST');
		this.getActiveManga();
	}

	getMangaPages() {
		this.mangaService.getMangaPages(this.manga.id).subscribe(pages => {
			this.mangaPages = pages;
		});
	}

	goNextPage() {
		this.currentPage++;
	}

	goPrevPage() {
		this.currentPage--;
	}
	
	getActiveManga() {
		this.mangaService.activeManga$.subscribe(manga => {
			this.manga = manga;
			this.getMangaPages();
		});
	}

	getPage(index: number) {
		if (this.mangaPages) {
			console.log(this.mangaPages.pages[this.currentPage].pageImageBase64);
			return 'data:image/png;base64,' + this.mangaPages.pages[this.currentPage].pageImageBase64;
		}
		return '';
	}
}