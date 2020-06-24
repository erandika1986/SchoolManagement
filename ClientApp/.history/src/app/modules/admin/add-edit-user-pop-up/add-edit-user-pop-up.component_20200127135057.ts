import { Component, OnInit, Inject } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { DropDownModel } from '../../../models/common/drop-down.model';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

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

  recordId = 0;

  constructor(private bsModalService: BsModalService,
    public modalRef: BsModalRef,
    private formBuilder: FormBuilder,
    public matDialogRef: MatDialogRef<AddEditUserPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data) { }

  ngOnInit() {
    console.log(this.data);
  }

  hideModal() {
    this.matDialogRef.close();
  }

  loadData() {
    if (this.recordId === 0) {
      console.log('set initial form');
    } else {
      this.getUserDetailsById();
    }
  }

  getUserDetailsById() {
    console.log('getUserDetailsById()');
  }

  // hideModal() {
  //   this.modalRef.hide();
  // }

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
