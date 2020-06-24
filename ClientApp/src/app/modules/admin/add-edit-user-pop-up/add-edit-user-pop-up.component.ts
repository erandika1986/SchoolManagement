import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { DropDownModel } from '../../../models/common/drop-down.model';
import { FormGroup, FormBuilder, FormControl, FormArray } from '@angular/forms';
import { UserService } from '../../../services/account/user.service';
import { ToastrService } from 'ngx-toastr';
import { UserModel } from '../../../models/account/user.model';
import { RoleModel } from '../../../models/account/role.model';

@Component({
  selector: 'app-add-edit-user-pop-up',
  templateUrl: './add-edit-user-pop-up.component.html',
  styleUrls: ['./add-edit-user-pop-up.component.css']
})
export class AddEditUserPopUpComponent implements OnInit {

  roles: DropDownModel[];
  roleData: [];
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
    this.setForm();
    this.loadData();
  }

  setForm() {
    this.form = this.formBuilder.group({
      id: [0],
      fullName: [''],
      email: [''],
      nickName: [''],
      username: [''],
      password: [''],
      mobileNo: [''],
      lstUserRole: [''],
      isActive: [true],
      roles: new FormArray([])
    });
  }

  getUserMasterData() {
    this.userService.getUserMasterData().subscribe(response => {
      this.roles = response.roles;
    }, err => {
      this.toastrService.error('Internal Server Error!');
    });
  }

  loadData() {
    if (this.recordId != 0) {
      this.getUserById(this.recordId);
    }
    else {
      this.getNewUser();
    }
  }

  getUserById(id: number) {
    this.userService.getUserById(id).subscribe(response => {
      this.user = response;
      this.form.get('id').setValue(this.user.id);
      this.form.get('fullName').setValue(this.user.fullName);
      this.form.get('email').setValue(this.user.email);
      this.form.get("email").disable();
      this.form.get('nickName').setValue(this.user.nickName);
      this.form.get('username').setValue(this.user.username);
      this.form.get("username").disable();
      this.form.get('password').setValue("********");
      this.form.get('password').disable();
      this.form.get('mobileNo').setValue(this.user.mobileNo);
      this.form.get('isActive').setValue(this.user.isActive);

      this.user.roles.map(control => (this.form.controls.roles as FormArray).push(new FormControl(control.isCheck)));
    }, err => {
      this.toastrService.error('Internal Server Error!');
    });
  }

  getNewUser() {
    this.userService.getNewUser().subscribe(response => {
      this.user = response;
      this.form.get('id').setValue(this.user.id);
      this.user.roles.map(control => (this.form.controls.roles as FormArray).push(new FormControl(control.isCheck)));


    }, err => {
      this.toastrService.error('Internal Server Error!');
    });
  }

  hideModal() {
    this.modalRef.content.answer = "close";
    this.modalRef.hide();
  }



  private addCheckboxes() {

  }

  saveOrUpdateUser() {

    const formValue = Object.assign({}, this.form.value, {
      roles: this.form.value.roles.map((selected, i) => {
        return {
          id: this.user.roles[i].id,
          isCheck: selected
        }
      })
    });

    if (this.form.value.id === 0) {

      this.userService.saveUser(formValue).subscribe(response => {
        this.isSuccess = response.isSuccess;
        this.message = response.message;
        if (this.isSuccess) {
          this.modalRef.content.answer = "Save";
          this.modalRef.hide();
          this.toastrService.success(this.message);
        } else {
          this.toastrService.error(this.message);
        }
      }, err => {
        this.toastrService.error('Internal Server Error!');
      });
    } else if (this.form.value.id !== 0) {

      this.userService.updateUser(formValue).subscribe(response => {
        this.isSuccess = response.isSuccess;
        this.message = response.message;
        if (this.isSuccess) {
          this.modalRef.content.answer = "Save";
          this.modalRef.hide();
          this.toastrService.success(this.message);
        } else {
          this.toastrService.error(this.message);
        }
      }, err => {
        this.toastrService.error('Internal Server Error!');
      });
    }
  }

  get userRoles() {
    return <FormArray>this.form.get('roles');
  };

}
