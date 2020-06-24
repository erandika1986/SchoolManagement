import { Component, OnInit, Inject } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { DropDownModel } from '../../../models/common/drop-down.model';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { UserService } from '../../../services/account/user.service';
import { ToastrService } from 'ngx-toastr';

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

  constructor(private formBuilder: FormBuilder,
    private userService: UserService,
    private toastrService: ToastrService,
    private bsModalService: BsModalService,
    public modalRef: BsModalRef,
    public matDialogRef: MatDialogRef<AddEditUserPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public data) { }

  ngOnInit() {
    this.getUserMasterData();
  }

  getUserMasterData() {
    this.userService.getUserMasterData().subscribe(response => {
      this.roles = response.roles;
      console.log(response);
    }, err => {
      this.toastrService.error('Internal Server Error!');
    });
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

  hideModal() {
    this.modalRef.hide();
  }
  // hideModal() {
  //   this.matDialogRef.close();
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
