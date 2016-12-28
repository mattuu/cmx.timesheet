import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TimesheetListComponent } from './timesheet-list/timesheet-list.component';
import { TimesheetService } from './timesheet.service';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
  	TimesheetListComponent
  ],
  declarations: [
  	TimesheetListComponent
  ],
  providers: [
  	TimesheetService
  ]
})
export class TimesheetModule { }
