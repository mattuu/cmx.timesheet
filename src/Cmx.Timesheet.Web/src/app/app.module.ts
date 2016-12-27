import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { TopNavModule } from './top-nav/top-nav.module';

import { AppComponent } from './app.component';
import { TimesheetListComponentComponent } from './timesheet-list-component/timesheet-list-component.component';

@NgModule({
  declarations: [
    AppComponent,
    TimesheetListComponentComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    TopNavModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
