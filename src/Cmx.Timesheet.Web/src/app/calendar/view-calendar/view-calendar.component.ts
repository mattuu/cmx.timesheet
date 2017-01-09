import { Component, OnInit } from '@angular/core';

import { CalendarViewComponent } from '../../shared/calendar-view/calendar-view.component';

@Component({
  selector: 'app-view-calendar',
  templateUrl: './view-calendar.component.html',
  styleUrls: ['./view-calendar.component.css']
})
export class ViewCalendarComponent implements OnInit {

  constructor() { 
  	this.startDate = new Date('2016-12-31');
  	this.endDate = new Date('2017-01-07');
  }

  public startDate: Date;
  public endDate: Date;

  ngOnInit() {
  }

}
