import { Component, OnInit, Inject } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { DropDownModel } from '../../../models/common/drop-down.model';
import { FormGroup, FormBuilder } from '@angular/forms';
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

  public user: any;

  constructor(private formBuilder: FormBuilder,
    private userService: UserService,
    private toastrService: ToastrService,
    private bsModalService: BsModalService,
    public modalRef: BsModalRef) { }

  ngOnInit() {
    this.getUserMasterData();
    this.setForm();
    this.loadData();
    console.log(this.user);
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

  addOrEditUser() {
    console.log('addOrEditUser()');
  }

  setForm() {
    this.form = this.formBuilder.group({
      id: [0],
      fullName: [''],
      email: [''],
      nickName: [''],
      userName: [''],
      mobileNo: [''],
      roles: []
    });
  }

}
