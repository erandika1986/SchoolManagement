import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { DropDownModel } from '../../../models/common/drop-down.model';
import { FormGroup, FormBuilder } from '@angular/forms';
import { UserService } from '../../../services/account/user.service';
import { ToastrService } from 'ngx-toastr';
import { UserModel } from '../../../models/account/user.model';

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

  userId;

  user: UserModel;

  constructor(private formBuilder: FormBuilder,
    private userService: UserService,
    private toastrService: ToastrService,
    private bsModalService: BsModalService,
    public modalRef: BsModalRef) { }

  ngOnInit() {
    this.getUserMasterData();
    this.recordId = this.userId;
    console.log('Record Id: ' + this.recordId);
    this.setForm();
    this.loadData();
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
      this.getUserById(this.recordId);
    }
  }

  getUserById(id: number) {
    console.log('getUserDetailsById()');
    this.userService.getUserById(id).subscribe(response => {
      this.user = response;
      console.log(response);
    }, err => {
      this.toastrService.error('Internal Server Error!');
    });
  }

  hideModal() {
    this.modalRef.hide();
  }

  saveOrUpdateUser() {
    console.log('saveOrUpdateUser()');
    if (this.recordId === 0) {
      this.userService.saveUser(this.form.value).subscribe(response => {
        this.isSuccess = response.isSuccess;
        this.message = response.message;
        if (this.isSuccess) {
          this.toastrService.success(this.message);
        } else {
          this.toastrService.error(this.message);
        }
      }, err => {
        this.toastrService.error('Internal Server Error!');
      });
    } else {
      this.userService.updateUser(this.form.value).subscribe(response => {
        this.isSuccess = response.isSuccess;
        this.message = response.message;
        if (this.isSuccess) {
          this.toastrService.success(this.message);
        } else {
          this.toastrService.error(this.message);
        }
      }, err => {
        this.toastrService.error('Internal Server Error!');
      });
    }
  }

  setForm() {
    this.form = this.formBuilder.group({
      id: [0],
      fullName: [''],
      email: [''],
      nickName: [''],
      userName: [''],
      mobileNo: [''],
      roles: [null]
    });
  }

}
