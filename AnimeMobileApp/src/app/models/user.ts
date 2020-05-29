import { Manga } from "./manga";
import { Anime } from "./anime";

export class User {
    id: number;
    login: string;
    password: string;
    isAdmin: boolean;
    favoritesMangas: Array<Manga>;
    favoritesAnimes: Array<Anime>;
}