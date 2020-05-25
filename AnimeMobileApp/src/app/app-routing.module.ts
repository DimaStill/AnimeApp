import { NgModule } from "@angular/core";
import { Routes } from "@angular/router";
import { NativeScriptRouterModule } from "nativescript-angular/router";
import { UserIdentificationComponent } from "./user-identification/user-identification.component";
import { AnimeListComponent } from "./anime-list/anime-list.component";
import { MangaListComponent } from "./manga-list/manga-list.component";

const routes: Routes = [
    { path: "", redirectTo: "/manga-list", pathMatch: "full" },
    { path: "identification-user", component: UserIdentificationComponent },
    { path: "anime-list", component: AnimeListComponent },
    { path: "manga-list", component: MangaListComponent },
    { path: "browse", loadChildren: () => import("~/app/browse/browse.module").then((m) => m.BrowseModule) },
    { path: "search", loadChildren: () => import("~/app/search/search.module").then((m) => m.SearchModule) },
    { path: "featured", loadChildren: () => import("~/app/featured/featured.module").then((m) => m.FeaturedModule) },
    { path: "settings", loadChildren: () => import("~/app/settings/settings.module").then((m) => m.SettingsModule) }
];

@NgModule({
    imports: [NativeScriptRouterModule.forRoot(routes)],
    exports: [NativeScriptRouterModule]
})
export class AppRoutingModule { }
