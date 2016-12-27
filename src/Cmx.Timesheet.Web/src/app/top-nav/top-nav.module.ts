import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TopNavComponent } from "./top-nav.component";

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
  	TopNavComponent
  ],
  declarations: [
  	TopNavComponent
  ]
})
export class TopNavModule { }
