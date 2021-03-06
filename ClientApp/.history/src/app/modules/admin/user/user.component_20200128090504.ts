import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder } from '@angular/forms';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { UserService } from '../../../services/account/user.service';
import { DialogDataModel } from '../../../models/common/dialog-data.model';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationDialogComponent } from '../../shared/confirmation-dialog/confirmation-dialog.component';
import { UserModel } from '../../../models/account/user.model';
import { AddEditUserPopUpComponent } from '../add-edit-user-pop-up/add-edit-user-pop-up.component';
import { DropDownModel } from '../../../models/common/drop-down.model';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  all = {
    'id': 0,
    'name': 'All'
  };

  name = '';
  roleId = 0;
  sortBy = '';

  totalRecordCount = 0;
  totalPageCount = 0;
  currentPage = 1;
  pageSize = 1;

  data: UserModel[];

  roles: DropDownModel[];

  public bsModalRef: BsModalRef;

  constructor(private toastrService: ToastrService,
    private ngxSpinnerService: NgxSpinnerService,
    private formBuilder: FormBuilder,
    private userService: UserService,
    public matDialog: MatDialog,
    private bsModalService: BsModalService) { }

  ngOnInit() {
    this.getUserList();
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

  openModal(userId: number) {
    this.bsModalRef = this.bsModalService.show(AddEditUserPopUpComponent, {class: 'modal-lg', backdrop: 'static'});
  }

  onPageChange() {
    this.getUserList();
  }

  getUserList() {
    console.log('getUserList()');
    console.log('name: ' + this.name );
    console.log('roleId: ' + this.roleId);
    console.log('currentPage: ' + this.currentPage);
    console.log('pageSize: ' + this.pageSize);
    console.log('sortBy: ' + this.sortBy);
    this.ngxSpinnerService.show();
    this.userService.getUserList(this.name,
      this.roleId, this.currentPage, this.pageSize, this.sortBy).subscribe(response => {
        console.log(response);
        this.data = response.data;
        this.ngxSpinnerService.hide();
        this.totalRecordCount = response.totalRecordCount;
        this.pageSize = this.pageSize;
        this.currentPage = response.currentPage;
        this.totalPageCount = response.totalPageCount;
      }, err => {
        this.toastrService.error('Internal Server Error!');
      });
  }

  deleteUser(id: number) {
    console.log('deleteUser()');
    const data: DialogDataModel = new DialogDataModel();
    data.header = 'Please confirm.';
    data.message = 'Do you really want to delete this selected record ?';
    const dialogRef = this.matDialog.open(ConfirmationDialogComponent, {
      width: '250px',
      data: data
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.ngxSpinnerService.show();
        this.userService.deleteUser(id).subscribe(response => {
          this.ngxSpinnerService.hide();
          if (response.isSuccess === true) {
            this.toastrService.success(response.message);
            this.getUserList();
          } else {
            this.toastrService.error(response.message);
          }
        }, error => {
          this.ngxSpinnerService.hide();
          this.toastrService.error('Internal Server Error!');
        });
      }
    });
  }

  sortByName() {
    console.log('sortByName()');
    console.log('name: ' + this.name );
    console.log('roleId: ' + this.roleId);
    console.log('currentPage: ' + this.currentPage);
    console.log('pageSize: ' + this.pageSize);
    console.log('sortBy: ' + this.sortBy);
    this.sortBy = 'FullName';
    this.getUserList();
    this.sortBy = '';
  }

  sortByUserName() {
    console.log('sortByUserName()');
    console.log('name: ' + this.name );
    console.log('roleId: ' + this.roleId);
    console.log('currentPage: ' + this.currentPage);
    console.log('pageSize: ' + this.pageSize);
    console.log('sortBy: ' + this.sortBy);
    this.sortBy = 'UserName';
    this.getUserList();
    this.sortBy = '';
  }

  sortByNickName() {
    console.log('sortByNickName()');
    console.log('name: ' + this.name );
    console.log('roleId: ' + this.roleId);
    console.log('currentPage: ' + this.currentPage);
    console.log('pageSize: ' + this.pageSize);
    console.log('sortBy: ' + this.sortBy);
    this.sortBy = 'NickName';
    this.getUserList();
    this.sortBy = '';
  }

  sortByEmail() {
    console.log('sortByEmail()');
    console.log('name: ' + this.name );
    console.log('roleId: ' + this.roleId);
    console.log('currentPage: ' + this.currentPage);
    console.log('pageSize: ' + this.pageSize);
    console.log('sortBy: ' + this.sortBy);
    this.sortBy = 'Email';
    this.getUserList();
    this.sortBy = '';
  }

  sortByMobileNo() {
    console.log('sortByMobileNo()');
    this.sortBy = 'MobileNo';
    console.log('name: ' + this.name + '|'
    + 'roleId: ' + this.roleId
    + '|' + 'currentPage: ' + this.currentPage + '|'
    + 'pageSize: ' + this.pageSize + '|' +
    'sortBy: ' + this.sortBy);
    this.getUserList();
    this.sortBy = '';
  }

  roleOnChange() {
    console.log('roleOnChange()');
    console.log('name: ' + this.name );
    console.log('roleId: ' + this.roleId);
    console.log('currentPage: ' + this.currentPage);
    console.log('pageSize: ' + this.pageSize);
    console.log('sortBy: ' + this.sortBy);
    this.getUserList();
  }

  searchOnClick() {
    console.log('searchOnClick()');
    console.log('name: ' + this.name );
    console.log('roleId: ' + this.roleId);
    console.log('currentPage: ' + this.currentPage);
    console.log('pageSize: ' + this.pageSize);
    console.log('sortBy: ' + this.sortBy);
    this.getUserList();
  }
}
