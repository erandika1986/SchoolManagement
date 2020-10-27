import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TimeTableListComponent } from './time-table-list/time-table-list.component';
import { TimeTableRoutingModule } from './time-table-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ModalModule } from 'ngx-bootstrap/modal';
import { MatDialogModule } from '@angular/material';
import { SharedModule } from '../shared/shared.module';
import { NgSelectModule } from '@ng-select/ng-select';



@NgModule({
  declarations: [TimeTableListComponent],
  imports: [
    CommonModule,
    TimeTableRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    PaginationModule.forRoot(),
    ModalModule.forRoot(),
    MatDialogModule,
    SharedModule,
    //NgxDialogModule.forRoot(),
    NgSelectModule
  ]
})
export class TimetableModule { }
