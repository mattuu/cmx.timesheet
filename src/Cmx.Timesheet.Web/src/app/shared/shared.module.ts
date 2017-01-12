import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { EditWorkdayComponent } from './edit-workday/edit-workday.component';
import { CalendarViewComponent } from './calendar-view/calendar-view.component';
import { WorkdayFormComponent } from './workday-form/workday-form.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    CalendarViewComponent,
  	EditWorkdayComponent,
    WorkdayFormComponent
  ],
  declarations: [
    CalendarViewComponent,
  	EditWorkdayComponent,
    WorkdayFormComponent
  ]
})
export class SharedModule { }
