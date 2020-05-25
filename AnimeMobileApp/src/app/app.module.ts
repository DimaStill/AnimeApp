import { NgModule, NO_ERRORS_SCHEMA } from "@angular/core";
import { NativeScriptModule } from "nativescript-angular/nativescript.module";
import { NativeScriptUISideDrawerModule } from "nativescript-ui-sidedrawer/angular";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { UserIdentificationComponent } from "./user-identification/user-identification.component";
import { AnimeListComponent } from "./anime-list/anime-list.component";
import { AnimeCardComponent } from "./anime-list/anime-card/anime-card.component";
import { AnimeInfoComponent } from "./anime-list/anime-info/anime-info.component";
import { MangaListComponent } from "./manga-list/manga-list.component";
import { MangaCardComponent } from "./manga-list/manga-card/manga-card.component";
import { MangaInfoComponent } from "./manga-list/manga-info/manga-info.component";

@NgModule({
    bootstrap: [
        AppComponent
    ],
    imports: [
        AppRoutingModule,
        NativeScriptModule,
        NativeScriptUISideDrawerModule
    ],
    declarations: [
        AppComponent,
        UserIdentificationComponent,
        AnimeListComponent,
        AnimeCardComponent,
        AnimeInfoComponent,
        MangaListComponent,
        MangaCardComponent,
        MangaInfoComponent
    ],
    schemas: [
        NO_ERRORS_SCHEMA
    ]
})
export class AppModule { }
