import { provideRouter, RouterConfig } from "@angular/router";

import {HOME_ROUTES} from "./home/home.routes";
import {TIMESHEET_ROUTES} from "./timesheet/timesheet.routes";

export const APP_ROUTES: RouterConfig = [
    ...HOME_ROUTES,
    ...TIMESHEET_ROUTES
];

export const APP_ROUTER_PROVIDERS = [
    provideRouter(APP_ROUTES)
];
