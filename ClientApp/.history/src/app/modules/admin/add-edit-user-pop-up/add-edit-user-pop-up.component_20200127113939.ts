import { Component, OnInit, Input } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { DropDownModel } from '../../../models/common/drop-down.model';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-add-edit-user-pop-up',
  templateUrl: './add-edit-user-pop-up.component.html',
  styleUrls: ['./add-edit-user-pop-up.component.css']
})
export class AddEditUserPopUpComponent implements OnInit {

  roles: DropDownModel[];

  form: FormGroup;

  isSuccess: boolean;
  message: string;

  @Input() public receivedData;

  recordId = 0;

  constructor(private bsModalService: BsModalService,
    private modalRef: BsModalRef,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.recordId = this.receivedData.id;
  }

  loadData() {
    if(this.recordId === 0) {
      console.log('set initial form');
    } else {
      this.getUserDetailsById();
    }
  }

  getUserDetailsById() {
    console.log('getUserDetailsById()');
  }

  hideModal() {
    this.modalRef.hide();
  }

  addOrEditUser() {
    console.log('addOrEditUser()');
  }

  setForm() {
    this.form = this.formBuilder.group({
      id: [0],
      email: [''],
      nickName: [''],
      userName: ['']
    });
  }

}
