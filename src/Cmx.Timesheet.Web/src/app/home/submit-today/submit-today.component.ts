import { Component, OnInit } from '@angular/core';

import { WorkdayFormComponent } from '../../shared/workday-form/workday-form.component';

@Component({
  selector: 'app-submit-today',
  templateUrl: './submit-today.component.html',
  styleUrls: ['./submit-today.component.css']
})
export class SubmitTodayComponent implements OnInit {

  constructor() { }

  public today: Date;

  ngOnInit() {
  	this.today = new Date();
  }

}
