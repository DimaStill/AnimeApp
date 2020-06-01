import { Component, OnInit } from "@angular/core";
import { NavigationEnd, Router } from "@angular/router";
import { RouterExtensions } from "nativescript-angular/router";
import { DrawerTransitionBase, RadSideDrawer, SlideInOnTopTransition } from "nativescript-ui-sidedrawer";
import { filter } from "rxjs/operators";
import * as app from "tns-core-modules/application";
import Theme from "nativescript-theme-core";
import { User } from "./models/user";
import { UserService } from "./services/userService";

@Component({
    selector: "ns-app",
    templateUrl: "app.component.html"
})
export class AppComponent implements OnInit {
    private isLightMode = true;
    private _activatedUrl: string;
    private _sideDrawerTransition: DrawerTransitionBase;
    activeUser: User;

    constructor(private router: Router, private routerExtensions: RouterExtensions, private userService: UserService) {
        // Use the component constructor to inject services.
    }

    ngOnInit(): void {
        this.getActiveUser();
        this._activatedUrl = "/home";
        this._sideDrawerTransition = new SlideInOnTopTransition();

        this.router.events
        .pipe(filter((event: any) => event instanceof NavigationEnd))
        .subscribe((event: NavigationEnd) => this._activatedUrl = event.urlAfterRedirects);
    }

    get sideDrawerTransition(): DrawerTransitionBase {
        return this._sideDrawerTransition;
    }

    isComponentSelected(url: string): boolean {
        return this._activatedUrl === url;
    }

    onNavItemTap(navItemRoute: string): void {
        this.routerExtensions.navigate([navItemRoute], {
            transition: {
                name: "fade"
            }
        });

        const sideDrawer = <RadSideDrawer>app.getRootView();
        sideDrawer.closeDrawer();
    }

    changeMode() {
        this.isLightMode = !this.isLightMode;
        Theme.setMode(
            Theme.getMode() === Theme.Light ? Theme.Dark : Theme.Light
        );
    }

    getActiveUser() {
        this.userService.activeUser$.subscribe(user => {
            this.activeUser = user;
        })
    }
}
