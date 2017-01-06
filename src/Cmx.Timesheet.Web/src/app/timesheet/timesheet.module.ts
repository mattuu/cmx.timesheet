import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TimesheetListComponent } from './timesheet-list/timesheet-list.component';
import { CreateTimesheetComponent } from './create-timesheet/create-timesheet.component';
import { CreateTimesheetFormComponent } from './create-timesheet/create-timesheet-form/create-timesheet-form.component';

import { TimesheetService } from './timesheet.service';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
  	TimesheetListComponent,
    CreateTimesheetComponent
  ],
  declarations: [
    CreateTimesheetFormComponent
  ],
  providers: [
  	TimesheetService
  ]
})
export class TimesheetModule { }
