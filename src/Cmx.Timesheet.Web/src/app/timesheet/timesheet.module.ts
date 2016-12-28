import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TimesheetListComponent } from './timesheet-list/timesheet-list.component';
 
@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
  	TimesheetListComponent
  ],
  declarations: [
  	TimesheetListComponent
  ]
})
export class TimesheetModule { }
