import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { Genre } from "../models/genre";
import { HttpClient } from "@angular/common/http";

@Injectable({
	providedIn: 'root',
})
export class GenreService {

	activeUser$ = new BehaviorSubject<Genre>(undefined);

	constructor(private httpClient: HttpClient) { }

}