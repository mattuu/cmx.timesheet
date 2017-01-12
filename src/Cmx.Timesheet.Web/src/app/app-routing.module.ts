import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { HomeModule } from './home/home.module';
import { TimesheetModule } from './timesheet/timesheet.module';

import { HomeComponent } from './home/home.component';
import { TimesheetListComponent } from './timesheet/timesheet-list/timesheet-list.component';
import { CreateTimesheetComponent } from './timesheet/create-timesheet/create-timesheet.component';

const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'timesheet', component: TimesheetListComponent },
  { path: 'create-timesheet', component: CreateTimesheetComponent }
];

@NgModule({
  imports: [
  	RouterModule.forRoot(routes)
  ],
  exports: [
  	RouterModule
  ]
})
export class AppRoutingModule { }
