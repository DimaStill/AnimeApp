import { Component, OnInit, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { serverUrl } from '../urlConstants';
import { Observable, Subject, BehaviorSubject } from 'rxjs';
import { User } from '../models/user';
import { Anime } from '../models/anime';

@Injectable({
	providedIn: 'root',
})
export class AnimeService {

	activeUser$ = new BehaviorSubject<Anime>(undefined);

	constructor(private httpClient: HttpClient) { }

	getAllAnime(): Observable<Array<Anime>> {
		return this.httpClient.get<Array<Anime>>(`${serverUrl}/api/anime/GetAllAnimes`);
	}

	setActiveAnime(anime: Anime) {
		this.activeUser$.next(anime);
	}
}