import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { EventService } from '../../services/common/event.service';



@NgModule({
  declarations: [ConfirmationDialogComponent],
  imports: [
    ModalModule.forRoot()
  ],
  providers: [EventService],
  entryComponents: []
})
export class SharedModule { }
