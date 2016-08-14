import { Injectable } from "@angular/core";
import { Http, Headers, RequestOptions } from "@angular/http";
import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";

import { Timesheet } from "./timesheet.model";

@Injectable()
export class TimesheetService {

	constructor(private http: Http) { }

	getList(): Observable<Timesheet[]> {
		return this.http.get("http://localhost:3592/api/timesheet")
			.map(res => res.json() as Timesheet[]);
	}
}