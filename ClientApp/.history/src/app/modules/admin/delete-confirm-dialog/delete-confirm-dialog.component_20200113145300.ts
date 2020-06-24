import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { UserService } from '../../../services/account/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-delete-confirm-dialog',
  templateUrl: './delete-confirm-dialog.component.html',
  styleUrls: ['./delete-confirm-dialog.component.css']
})
export class DeleteConfirmDialogComponent implements OnInit {

  public bsModalRef: BsModalRef;

  isSuccess: boolean;
  message: string;

  constructor(private bsModalService: BsModalService,
    private userService: UserService,
    private toastrService: ToastrService) { }

  ngOnInit() {
  }

  deleteUser(id: number) {
    console.log('deleteUser()');
    this.bsModalRef.hide();
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

  cancleDeleteConfirmDialog() {
    this.bsModalRef.hide();
  }

}
