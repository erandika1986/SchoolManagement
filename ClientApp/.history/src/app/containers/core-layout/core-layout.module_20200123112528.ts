import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoreLayoutRoutingModule } from './core-layout-routing.module';
import { CoreLayoutComponent } from './core-layout/core-layout.component';
import { LoginModule } from '../../modules/login/login.module';
import { LoginComponent } from '../../modules/login/login/login.component';


@NgModule({
  declarations: [CoreLayoutComponent, LoginComponent],
  imports: [
    CommonModule,
    CoreLayoutRoutingModule,
    LoginModule
  ]
})
export class CoreLayoutModule { }
