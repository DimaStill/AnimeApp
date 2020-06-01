import { Manga } from "./manga";
import { Anime } from "./anime";

export class User {
    id: number;
    login: string;
    password: string;
    isAdmin: boolean;
    favoritesMangaIds: Array<number>;
    favoritesAnimeIds: Array<number>;
}