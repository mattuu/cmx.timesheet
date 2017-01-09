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
<<<<<<< 7d76f88a60921aceb57e0035d73f58bacdc2579e
=======
    CreateTimesheetFormComponent,
    TimesheetListComponent,
    CreateTimesheetComponent    
>>>>>>> Workday edit form added to create timesheet page
  ],
  providers: [
  	TimesheetService
  ]
})
export class TimesheetModule { }
