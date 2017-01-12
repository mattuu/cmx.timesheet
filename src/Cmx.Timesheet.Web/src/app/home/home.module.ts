import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';

import { HomeComponent } from './home.component';
import { SubmitTodayComponent } from './submit-today/submit-today.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
  	HomeComponent
  ],
  declarations: [
  	HomeComponent,
  	SubmitTodayComponent
  ]
})
export class HomeModule { }
