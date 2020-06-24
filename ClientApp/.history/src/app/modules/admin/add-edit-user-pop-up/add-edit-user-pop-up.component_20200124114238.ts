import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-add-edit-user-pop-up',
  templateUrl: './add-edit-user-pop-up.component.html',
  styleUrls: ['./add-edit-user-pop-up.component.css']
})
export class AddEditUserPopUpComponent implements OnInit {

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
