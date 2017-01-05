import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs/Observable'; 

import { TimesheetService } from '../timesheet.service';
import { TimesheetItem } from '../timesheet.models';

@Component({
  selector: 'app-timesheet-list',
  templateUrl: './timesheet-list.component.html',
  styleUrls: ['./timesheet-list.component.css']
})
export class TimesheetListComponent implements OnInit {

  constructor(private timesheetService: TimesheetService) { }

  public timesheets$: Observable<Array<TimesheetItem>> = new Observable<Array<TimesheetItem>>();

  ngOnInit() {
  	this.timesheets$ = this.timesheetService.GetAll();
  }

}
