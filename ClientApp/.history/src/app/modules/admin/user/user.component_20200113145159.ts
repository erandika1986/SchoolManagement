import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder } from '@angular/forms';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { UserService } from '../../../services/account/user.service';
import { DeleteConfirmDialogComponent } from '../delete-confirm-dialog/delete-confirm-dialog.component';

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

  name: string;
  roleId: string;
  currentPage: number;
  pageSize: number;
  sortBy: string;

  totalRecordCount: number;

  isSuccess: boolean;
  message: string;

  constructor(private toastrService: ToastrService,
    private formBuilder: FormBuilder,
    private bsModalService: BsModalService,
    private userService: UserService) { }

  ngOnInit() {
    this.getUserList();
  }

  onPageChange() {
    this.getUserList();
  }

  getUserList() {
    console.log('getUserList()');
    this.userService.getUserList(this.name,
      this.roleId, this.currentPage, this.pageSize, this.sortBy).subscribe(response => {
        console.log(response);
      }, err => {
        this.toastrService.error('Internal Server Error!');
      });
  }

  openDeleteConfirmDialog() {
    this.bsModalRef = this.bsModalService.show(DeleteConfirmDialogComponent, { class: 'modal-sm' });
  }

}
