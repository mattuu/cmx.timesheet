import { provideRouter, RouterConfig } from "@angular/router";

import {HOME_ROUTES} from "./home/home.routes";

export const APP_ROUTES: RouterConfig = [
    ...HOME_ROUTES
];

export const APP_ROUTER_PROVIDERS = [
    provideRouter(APP_ROUTES)
];
