import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { TimesheetModule } from './timesheet/timesheet.module';
import { TimesheetListComponent } from './timesheet/timesheet-list/timesheet-list.component';
import { CreateTimesheetComponent } from './timesheet/create-timesheet/create-timesheet.component';

const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full' },
  { path: 'timesheet', component: TimesheetListComponent },
  { path: 'create-timesheet', component: CreateTimesheetComponent }
  // { path: 'dashboard',  component: DashboardComponent },
  // { path: 'detail/:id', component: HeroDetailComponent },
  // { path: 'heroes',     component: HeroesComponent }
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
