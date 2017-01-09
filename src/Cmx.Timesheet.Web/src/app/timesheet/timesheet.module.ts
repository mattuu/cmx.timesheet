import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../shared/shared.module';
import { CalendarModule } from '../calendar/calendar.module';

import { TimesheetListComponent } from './timesheet-list/timesheet-list.component';
import { CreateTimesheetComponent } from './create-timesheet/create-timesheet.component';

import { TimesheetService } from './timesheet.service';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    CalendarModule
  ],
  exports: [
  	TimesheetListComponent,
    CreateTimesheetComponent
  ],
  declarations: [
  ],
  providers: [
  	TimesheetService
  ]
})
export class TimesheetModule { }
