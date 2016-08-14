import { Component, OnInit } from "@angular/core";

import { Timesheet } from "../shared/timesheet.model";
import { TimesheetService } from "../shared/timesheet.service";

@Component({
	// selector: "timesheet-list",
	templateUrl: "timesheet-list.component.html",
	providers: [TimesheetService]
})

export class TimesheetListComponent implements OnInit {
	timesheets: Timesheet[] = [];

	constructor(private timesheetService: TimesheetService) {
		console.log("TIMESHEET LIST COMPONENT")
	 }

	ngOnInit() {
		this.timesheetService.getList().subscribe((res) => {
			this.timesheets = res;
		});
	}
}