import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { DropDownModel } from '../../../models/common/drop-down.model';

@Component({
  selector: 'app-add-edit-user-pop-up',
  templateUrl: './add-edit-user-pop-up.component.html',
  styleUrls: ['./add-edit-user-pop-up.component.css']
})
export class AddEditUserPopUpComponent implements OnInit {

  roles: DropDownModel[];

  constructor(private bsModalService: BsModalService,
    private modalRef: BsModalRef) { }

  ngOnInit() {
  }

  hideModal() {
    this.modalRef.hide();
  }

  addOrEditUser() {
    console.log('addOrEditUser()');
  }

}
