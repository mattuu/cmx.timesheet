import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../shared/shared.module';
import { WorkdayFormComponent } from './workday-form/workday-form.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
  	WorkdayFormComponent
  ],
  declarations: [
  	WorkdayFormComponent
  ]
})
export class CalendarModule { }
