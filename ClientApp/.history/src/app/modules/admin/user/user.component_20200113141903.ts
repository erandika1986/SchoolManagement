import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder } from '@angular/forms';
import { BsModalService } from 'ngx-bootstrap/modal';
import { UserService } from '../../../services/account/user.service';

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

  name: string;
  roleId: string;
  currentPage: number;
  pageSize: number;
  sortBy: string;

  isSuccess: boolean;
  message: string;

  constructor(private toastrService: ToastrService,
    private formBuilder: FormBuilder,
    private bsModalService: BsModalService,
    private userService: UserService) { }

  ngOnInit() {
  }

  getUserList() {
    this.userService.getUserList(this.name,
      this.roleId, this.currentPage, this.pageSize, this.sortBy).subscribe(response => {
        console.log(response);
      }, err => {
        this.toastrService.error('Internal Server Error!');
      });
  }

  deleteUser(id: number) {
    this.userService.deleteUser(id).subscribe(response => {
      if (response.isSuccess === true) {
        this.toastrService.success(response.message);
      } else {
        this.toastrService.success(response.message);
      }
    }, err => {
      this.toastrService.error('Internal Server Error!');
    });
  }

}
