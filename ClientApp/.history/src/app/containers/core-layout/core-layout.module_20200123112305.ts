import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoreLayoutRoutingModule } from './core-layout-routing.module';
import { CoreLayoutComponent } from './core-layout/core-layout.component';
import { LoginModule } from '../../modules/login/login.module';


@NgModule({
  declarations: [CoreLayoutComponent],
  imports: [
    CommonModule,
    CoreLayoutRoutingModule,
    LoginModule
  ]
})
export class CoreLayoutModule { }
