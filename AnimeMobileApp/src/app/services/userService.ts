import { Component, OnInit, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { serverUrl } from '../urlConstants';
import { Observable, Subject } from 'rxjs';
import { User } from '../models/user';

@Injectable({
	providedIn: 'root',
})
export class UserService {

	activeUser$: Subject<User>;

	constructor(private httpClient: HttpClient) { }

	loginUser(body): Observable<User> {
		return this.httpClient.post<User>(`${serverUrl}/api/user/LoginUser`, body);
	}

	registration(body): Observable<User> {
		return this.httpClient.post<User>(`${serverUrl}/api/user`, body);
	}

	setActiveUser(user: User) {
		this.activeUser$.next(user);
	}
}