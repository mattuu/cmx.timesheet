import { Component, OnInit, Input } from '@angular/core';
import * as calendar from 'calendar';

@Component({
  selector: 'calendar-view',
  templateUrl: './calendar-view.component.html',
  styleUrls: ['./calendar-view.component.css']
})
export class CalendarViewComponent implements OnInit {

  constructor() { }

  @Input()
  public startDate: Date;
  
  @Input()
  public endDate: Date;

  public weekdays: Array<string>  = [];
  public calendar: Array<Array<Date>>  = [];

  ngOnInit() {

  	this.weekdays.push("Mon");
  	this.weekdays.push("Tue");
  	this.weekdays.push("Wed");
  	this.weekdays.push("Thu");
  	this.weekdays.push("Fri");
  	this.weekdays.push("Sat");
  	this.weekdays.push("Sun");
	
	  let cMon = new calendar.Calendar(1); // weeks starts on Monday
 	  let mdc = cMon.monthDays(2016, 0);

 	  mdc.map(week => this.calendar.push(week));
  }
}
