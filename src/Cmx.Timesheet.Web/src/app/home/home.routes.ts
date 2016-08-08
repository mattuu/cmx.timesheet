import { RouterConfig }          from "@angular/router";
import { HomeComponent }     from "./home.component";

export const HOME_ROUTES: RouterConfig = [
    { path: "", redirectTo: "home" },
    { path: "home", component: HomeComponent }
];
