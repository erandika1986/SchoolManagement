import { Component, OnInit, Inject, EventEmitter, Output } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DialogDataModel } from '../../../models/common/dialog-data.model';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { EventService } from '../../../services/common/event.service';

@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styleUrls: ['./confirmation-dialog.component.css']
})
export class ConfirmationDialogComponent implements OnInit {

  Id;
  constructor(
    private eventService: EventService,
    public bsModalRef: BsModalRef) { }

  ngOnInit() {
  }

  confirm() {
    this.eventService.deleteconfirmed(this.Id);
  }

  decline() {
    this.bsModalRef.hide();
  }
}
