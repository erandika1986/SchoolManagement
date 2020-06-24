import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder } from '@angular/forms';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { UserService } from '../../../services/account/user.service';
import { DialogDataModel } from '../../../models/common/dialog-data.model';
import { MatDialog } from '@angular/material';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationDialogComponent } from '../../shared/confirmation-dialog/confirmation-dialog.component';
import { UserModel } from '../../../models/account/user.model';
import { AddEditUserPopUpComponent } from '../add-edit-user-pop-up/add-edit-user-pop-up.component';

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

  public bsModalRef: BsModalRef;

  name: null;
  roleId: null;
  sortBy: null;

  totalRecordCount = 0;
  totalPageCount = 0;
  currentPage = 1;
  pageSize: 0;

  data: UserModel[];

  public modalRef: BsModalRef;

  constructor(private toastrService: ToastrService,
    private formBuilder: FormBuilder,
    private bsModalService: BsModalService,
    private userService: UserService,
    private ngxSpinnerService: NgxSpinnerService,
    public dialog: MatDialog) { }

  ngOnInit() {
    this.getUserList();
  }

  onPageChange() {
    this.getUserList();
  }

  getUserList() {
    console.log('getUserList()');
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
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
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

  openAddOrEditPopUp() {
    this.modalRef = this.bsModalService.show(AddEditUserPopUpComponent);
  }

  sortByName() {
    console.log('sortByName()');
  }

  sortByUserName() {
    console.log('sortByUserName()');
  }

  sortByNickName() {
    console.log('sortByNickName()');
  }

  sortByEmail() {
    console.log('sortByEmail()');
  }

  sortByUserRole() {
    console.log('sortByUserRole()');
  }

  sortByUpdatedOn() {
    console.log('sortByUpdatedOn()');
  }

  sortByUpdatedBy() {
    console.log('sortByUpdatedBy()');
  }

  roleOnChange() {
    console.log('roleOnChange()');
  }

  searchOnClick() {
    console.log('searchOnClick()');
  }
}
