import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoreLayoutRoutingModule } from './core-layout-routing.module';
import { CoreLayoutComponent } from './core-layout/core-layout.component';


@NgModule({
  declarations: [CoreLayoutComponent],
  imports: [
    CommonModule,
    CoreLayoutRoutingModule
  ]
})
export class CoreLayoutModule { }
