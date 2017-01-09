import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { EditWorkdayComponent } from './edit-workday/edit-workday.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
  	EditWorkdayComponent
  ],
  declarations: [
  	EditWorkdayComponent
  ]
})
export class SharedModule { }
