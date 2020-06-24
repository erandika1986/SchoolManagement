import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { UserComponent } from './user/user.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ModalModule } from 'ngx-bootstrap/modal';
import { MatDialogModule } from '@angular/material';
import { ConfirmationDialogComponent } from '../shared/confirmation-dialog/confirmation-dialog.component';
import { SharedModule } from '../shared/shared.module';
import { AddEditUserPopUpComponent } from './add-edit-user-pop-up/add-edit-user-pop-up.component';
import { NgxBootstrapMultiselectDropdownModule } from 'ngx-bootstrap-multiselect-dropdown/ngx-bootstrap-multiselect-dropdown';


@NgModule({
  declarations: [UserComponent, AddEditUserPopUpComponent],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    PaginationModule.forRoot(),
    ModalModule.forRoot(),
    MatDialogModule,
    SharedModule,
    NgxBootstrapMultiselectDropdownModule   
  ],
  entryComponents: [ConfirmationDialogComponent, AddEditUserPopUpComponent]
})
export class AdminModule { }
