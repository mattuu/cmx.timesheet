import {enableProdMode} from "@angular/core";
import {bootstrap} from "@angular/platform-browser-dynamic";

import {AppComponent, APP_ROUTER_PROVIDERS} from "./app/index";

enableProdMode();
bootstrap(AppComponent, [APP_ROUTER_PROVIDERS]);
