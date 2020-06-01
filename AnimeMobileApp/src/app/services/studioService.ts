import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { Genre } from "../models/genre";
import { HttpClient } from "@angular/common/http";
import { serverUrl } from "../urlConstants";
import { Studio } from "../models/studio";

@Injectable({
	providedIn: 'root',
})
export class StudioService {

	activeGenre$ = new BehaviorSubject<Studio>(undefined);

	constructor(private httpClient: HttpClient) { }

	getStudio(id: number): Observable<Studio> {
		return this.httpClient.get<Studio>(`${serverUrl}/api/studio/${id}`);
	}
}