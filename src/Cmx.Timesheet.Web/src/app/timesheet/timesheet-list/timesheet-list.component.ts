import { Component, OnInit } from "@angular/core";
import { ROUTER_DIRECTIVES } from "@angular/router";

import { Timesheet } from "../shared/timesheet.model";
import { TimesheetService } from "../shared/timesheet.service";

@Component({
	// selector: "timesheet-list",
	moduleId: __moduleName,
	templateUrl: "timesheet-list.component.html",
	providers: [TimesheetService],
	directives: [ROUTER_DIRECTIVES]
})

export class TimesheetListComponent implements OnInit {
	timesheets: Timesheet[] = [];

	constructor(private timesheetService: TimesheetService) {
	}

	ngOnInit() {
		this.timesheetService.getList().subscribe((res) => {
			this.timesheets = res;
		});
	}
}