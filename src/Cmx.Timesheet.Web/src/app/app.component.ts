import { Component, OnInit} from "@angular/core";
import {ROUTER_DIRECTIVES} from "@angular/router";
import { HTTP_PROVIDERS } from "@angular/http";
import {Observable} from "rxjs/Observable";
import "rxjs/add/operator/share";

@Component({
  moduleId: __moduleName,
  selector: "app-name-template-app",
  templateUrl: "app.component.html",
  styleUrls: ["app.component.css"],
  directives: [ROUTER_DIRECTIVES],
  providers: [
    HTTP_PROVIDERS
  ]
})

export class AppComponent implements OnInit {
  userName$: Observable<string>;
  isSuperUser$: Observable<boolean>;
  constructor() { }

  ngOnInit() { }
}

