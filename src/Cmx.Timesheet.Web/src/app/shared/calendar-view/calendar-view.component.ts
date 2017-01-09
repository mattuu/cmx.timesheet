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

  // public rows: Array<<Array<Date>>  = [];
  public weekdays: Array<string>  = [];
  public weeks: Array<Array<Date>>  = [];
  public startDateOffset: Array<any>;

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

 	mdc.map(week => this.weeks.push(week));

  	// let week = new Array<Date>();
	// this.dates.push(week);

	// let date = this.startDate;
 //  	while(date <= this.endDate){
 //  		// if(date.getDay() == 0){
 //  		// 	week = new Array<Date>();
	//   	// 	this.dates.push(week);
 //  		// }

 //  		this.dates.push(new Date(date));

 //  		// console.log(d);
 //  		// week.push(d);

 //  		date.setDate(date.getDate() + 1);
 //  	}


 //  	this.startDateOffset = new Array(this.dates[0][0].getDate());
  }

 //  fillCalendar(): Array<Array<Date>> {
 //  	let dates = new Array<Array<Date>>();

 //  	let week = new Array<Date>();
	// this.dates.push(week);

	// let date = this.startDate;
 //  	while(date <= this.endDate){
 //  		if(date.getDay() == 0){
 //  			week = new Array<Date>();
	//   		dates.push(week);
 //  		}
 //  		let d = new Date(date);

 //  		console.log(d);
 //  		week.push(d);

 //  		date.setDate(date.getDate() + 1);
 //  	}	

 //  	return dates;
 //  }

  // calculateStartDateOffset()

}
