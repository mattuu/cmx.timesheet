import { Component, OnInit, Input } from '@angular/core';

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

  public dates: Array<Date>  = [];
  public weekdays: Array<string>  = [];

  ngOnInit() {

  	this.weekdays.push("Mon");
  	this.weekdays.push("Tue");
  	this.weekdays.push("Wed");
  	this.weekdays.push("Thu");
  	this.weekdays.push("Fri");
  	this.weekdays.push("Sat");
  	this.weekdays.push("Sun");

	let date = this.startDate;
  	while(date <= this.endDate){
  		this.dates.push(date);
  		date.setDate(date.getDate() + 1);
  	}
  }

}
