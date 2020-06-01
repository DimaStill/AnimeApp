import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { Genre } from "../models/genre";
import { HttpClient } from "@angular/common/http";
import { serverUrl } from "../urlConstants";

@Injectable({
	providedIn: 'root',
})
export class GenreService {

	activeGenre$ = new BehaviorSubject<Genre>(undefined);

	constructor(private httpClient: HttpClient) { }

	getGenre(id: number): Observable<Genre> {
		return this.httpClient.get<Genre>(`${serverUrl}/api/genre/${id}`);
	}
}