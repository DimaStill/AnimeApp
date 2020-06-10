import { Component, OnInit, Input, ElementRef, ViewChild } from '@angular/core';
import { MangaService } from '~/app/services/mangaService';
import { Anime } from '~/app/models/anime';
import { Manga } from '~/app/models/manga';
import { MangaPages } from '~/app/models/mangaPages';
import {ImageSource, fromFile, fromResource, fromBase64} from "tns-core-modules/image-source";
import { Image } from "tns-core-modules/ui/image";

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
	page = '';
	imageSource;
	@ViewChild("photoImage", {static: false}) photoImage: ElementRef;
	photo: Image;
	
	constructor(private mangaService: MangaService) { }

	ngOnInit() {
		console.log('TEST');
		this.getActiveManga();
	}

	getMangaPages() {
		this.mangaService.getMangaPages(this.manga.id).subscribe(pages => {
			this.mangaPages = pages;
			this.imageSource = new ImageSource();
			const loadedBase64 = this.imageSource.loadFromBase64(this.mangaPages.pages[0].pageImageBase64);
			console.log(loadedBase64);
			if (loadedBase64) {
			  let photo = <Image>this.photoImage.nativeElement;
			  photo.imageSource = this.imageSource;
			  this.photo = photo;
			}
		});
	}

	goNextPage() {
		this.currentPage++;
		this.imageSource = new ImageSource();
		const loadedBase64 = this.imageSource.loadFromBase64(this.mangaPages.pages[this.currentPage].pageImageBase64);
		console.log(loadedBase64);
		if (loadedBase64) {
		  let photo = <Image>this.photoImage.nativeElement;
		  photo.imageSource = this.imageSource;
		  this.photo = photo;
		}
	}

	goPrevPage() {
		this.currentPage--;
		this.imageSource = new ImageSource();
		const loadedBase64 = this.imageSource.loadFromBase64(this.mangaPages.pages[this.currentPage].pageImageBase64);
		console.log(loadedBase64);
		if (loadedBase64) {
		  let photo = <Image>this.photoImage.nativeElement;
		  photo.imageSource = this.imageSource;
		  this.photo = photo;
		}
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
	}
}