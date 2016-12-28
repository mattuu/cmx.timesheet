import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { TopNavComponent } from "./top-nav.component";

@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
  	TopNavComponent
  ],
  declarations: [
  	TopNavComponent
  ]
})
export class TopNavModule { }
