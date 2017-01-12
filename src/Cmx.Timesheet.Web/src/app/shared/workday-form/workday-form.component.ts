import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { EditWorkdayComponent } from '../edit-workday/edit-workday.component';
import { WorkDay } from '../shared.models';

@Component({
  selector: 'workday-form',
  templateUrl: './workday-form.component.html',
  styleUrls: ['./workday-form.component.css']
})
export class WorkdayFormComponent implements OnInit {

  constructor() { }

  @Input()
  public date: Date = new Date();

  @Output()
  public submitted: EventEmitter<WorkDay> = new EventEmitter<WorkDay>();

  workDay: WorkDay;

  ngOnInit() {
  	this.workDay = new WorkDay(this.date);
  }

  onSubmit(): void {
  	this.submitted.emit(this.workDay);
  }

}
