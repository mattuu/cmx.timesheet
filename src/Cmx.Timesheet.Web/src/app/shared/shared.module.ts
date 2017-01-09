import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { EditWorkdayComponent } from './edit-workday/edit-workday.component';
import { CalendarViewComponent } from './calendar-view/calendar-view.component';


@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
  	EditWorkdayComponent
  	CalendarViewComponent
  ],
  declarations: [
  	EditWorkdayComponent
  	CalendarViewComponent
  ]
})
export class SharedModule { }
