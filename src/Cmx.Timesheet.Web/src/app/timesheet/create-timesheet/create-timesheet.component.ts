import { Component, OnInit } from '@angular/core';

import { WorkdayFormComponent } from '../../shared/workday-form/workday-form.component';

@Component({
  selector: 'create-timesheet',
  templateUrl: './create-timesheet.component.html',
  styleUrls: ['./create-timesheet.component.css']
})
export class CreateTimesheetComponent implements OnInit {

  constructor() { }

  public date: Date;


  ngOnInit() {
  	this.date = new Date();
  }

  public onSubmitted(): void {
	console.log(this.date);
  }

}
