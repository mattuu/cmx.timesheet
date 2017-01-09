import { Component, OnInit } from '@angular/core';

import { EditWorkdayComponent } from '../../shared/edit-workday/edit-workday.component';
import { WorkDay } from '../../shared/shared.models';

@Component({
  selector: 'app-workday-form',
  templateUrl: './workday-form.component.html',
  styleUrls: ['./workday-form.component.css']
})
export class WorkdayFormComponent implements OnInit {

  constructor() { }

  workDay: WorkDay;

  ngOnInit() {
  	this.workDay = new WorkDay(new Date());
  }

}
