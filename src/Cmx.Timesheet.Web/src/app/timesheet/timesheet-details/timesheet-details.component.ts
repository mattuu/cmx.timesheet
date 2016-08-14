import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Subscription } from "rxjs/Subscription";

@Component({
	moduleId: __moduleName,
	templateUrl: "timesheet-details.component.html"
})

export class TimesheetDetailsComponent implements OnInit {
	timesheetId: string;
	sub: Subscription;

	constructor(private route: ActivatedRoute) {
	}

	ngOnInit() {
		this.sub = this.route.params.subscribe(params => {
			this.timesheetId = params['id']; 
		});
	}

	private ngOnDestroy() {
		this.sub.unsubscribe();
	}
}