import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { Observable } from 'rxjs/Observable'; 
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { AppRoutingModule } from './app-routing.module';
import { TopNavModule } from './top-nav/top-nav.module';
import { HomeModule } from './home/home.module';
import { SharedModule } from './shared/shared.module';
import { TimesheetModule } from './timesheet/timesheet.module';
import { CalendarModule } from './calendar/calendar.module';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule,
    TopNavModule,
    HomeModule,
    SharedModule,
    TimesheetModule,
    CalendarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
