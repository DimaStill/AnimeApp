import { NgModule } from "@angular/core";
import { Routes } from "@angular/router";
import { NativeScriptRouterModule } from "nativescript-angular/router";
import { UserIdentificationComponent } from "./user-identification/user-identification.component";
import { AnimeListComponent } from "./anime-list/anime-list.component";
import { MangaListComponent } from "./manga-list/manga-list.component";
import { AnimeInfoComponent } from "./anime-list/anime-info/anime-info.component";
import { MangaInfoComponent } from "./manga-list/manga-info/manga-info.component";
import { MangaReaderComponent } from "./manga-list/manga-reader/manga-reader.component";
import { FavoriteMangaComponent } from "./manga-list/favorite-manga/favorite-manga.component";
import { FavoriteAnimeComponent } from "./anime-list/favorite-anime/favorite-anime.component";

const routes: Routes = [
    { path: "", redirectTo: "/identification-user", pathMatch: "full" },
    { path: "identification-user", component: UserIdentificationComponent },
    { path: "anime-list", component: AnimeListComponent },
    { path: "manga-list", component: MangaListComponent },
    { path: "anime-info", component: AnimeInfoComponent },
    { path: "manga-info", component: MangaInfoComponent },
    { path: "manga-read", component: MangaReaderComponent },
    { path: "favorite-manga", component: FavoriteMangaComponent },
    { path: "favorite-anime", component: FavoriteAnimeComponent },
];

@NgModule({
    imports: [NativeScriptRouterModule.forRoot(routes)],
    exports: [NativeScriptRouterModule]
})
export class AppRoutingModule { }
