import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { Manga } from "../models/manga";
import { HttpClient } from "@angular/common/http";
import { serverUrl } from "../urlConstants";

@Injectable({
	providedIn: 'root',
})
export class MangaService {

	activeManga$ = new BehaviorSubject<Manga>(undefined);

	constructor(private httpClient: HttpClient) { }

	getAllMangas(): Observable<Array<Manga>> {
		return this.httpClient.get<Array<Manga>>(`${serverUrl}/api/manga`);
	}

	setActiveManga(anime: Manga) {
		this.activeManga$.next(anime);
	}
}