import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoreLayoutRoutingModule } from './core-layout-routing.module';
import { CoreLayoutComponent } from './core-layout/core-layout.component';
import { LoginComponent } from '../../modules/login/login/login.component';


@NgModule({
  declarations: [CoreLayoutComponent],
  imports: [
    CommonModule,
    CoreLayoutRoutingModule,
    LoginComponent
  ]
})
export class CoreLayoutModule { }
