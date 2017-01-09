import { Component, OnInit, Input } from '@angular/core';

import { WorkDay } from '../shared.models';

@Component({
  selector: 'edit-workday',
  templateUrl: './edit-workday.component.html',
  styleUrls: ['./edit-workday.component.css']
})
export class EditWorkdayComponent implements OnInit {

  constructor() { }

  @Input()
  public workDay: WorkDay;

  ngOnInit() {
  }

}
