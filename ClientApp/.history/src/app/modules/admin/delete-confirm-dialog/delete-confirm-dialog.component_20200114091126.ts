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


  cancleDeleteConfirmDialog() {
    this.bsModalRef.hide();
  }

}
