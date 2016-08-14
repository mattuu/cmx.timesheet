import { Component, OnInit } from "@angular/core";

import { Timesheet } from "./shared/timesheet.model";
import { TimesheetService } from "./shared/timesheet.service";

@Component({
	// selector: "cmx-timesheet",
	templateUrl: "timesheet.component.html",
	providers: [TimesheetService]
})

export class TimesheetComponent implements OnInit {
	timesheet: Timesheet[] = [];

	constructor(private timesheetService: TimesheetService) { }

	ngOnInit() {
		this.timesheetService.getList().subscribe((res) => {
			this.timesheet = res;
		});
	}
}
