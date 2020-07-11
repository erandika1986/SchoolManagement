import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { UserService } from '../../../services/account/user.service';
import { DialogDataModel } from '../../../models/common/dialog-data.model';
import { MatDialog } from '@angular/material';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationDialogComponent } from '../../shared/confirmation-dialog/confirmation-dialog.component';
import { UserModel } from '../../../models/account/user.model';
import { AddEditUserPopUpComponent } from '../add-edit-user-pop-up/add-edit-user-pop-up.component';
import { DropDownModel } from '../../../models/common/drop-down.model';
import { Subscription, combineLatest } from 'rxjs';
import { take } from 'rxjs/operators';
import { EventService } from '../../../services/common/event.service';

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

  statuses = [{ "text": "Active", "value": true }, { "text": "Inactive", "value": false }]
  selectedStatus = true;

  name = '';
  roleId = 0;
  sortBy = '';

  totalRecordCount = 0;
  totalPageCount = 0;
  currentPage = 1;
  pageSize = 15;

  data: UserModel[];

  roles: DropDownModel[];

  public bsModalRef: BsModalRef;
  public deleteModelRef: BsModalRef;

  subscriptions: Subscription[] = [];

  constructor(private toastrService: ToastrService,
    private ngxSpinnerService: NgxSpinnerService,
    private userService: UserService,
    public matDialog: MatDialog,
    private bsModalService: BsModalService,
    private changeDetection: ChangeDetectorRef,
    private eventService: EventService) {

  }

  ngOnInit() {
    this.getUserMasterData();
  }

  getUserMasterData() {
    this.userService.getUserMasterData().subscribe(response => {
      this.roles = response.roles;
      this.getUserList();
    }, err => {
      this.toastrService.error('Internal Server Error!');
    });
  }

  openModal(id: number) {

    const _combine = combineLatest(
      this.bsModalService.onHidden
    ).subscribe(() => this.changeDetection.markForCheck());

    this.subscriptions.push(
      this.bsModalService.onHidden.subscribe((reason: string) => {
        this.unsubscribe();
        this.getUserList();
      })
    );
    this.subscriptions.push(_combine);

    this.bsModalRef = this.bsModalService.show(AddEditUserPopUpComponent,
      {
        class: 'modal-lg modal-dialog-centered',
        backdrop: 'static',
        keyboard: false,
        initialState: {
          userId: id
        }
      });
  }

  unsubscribe() {
    this.subscriptions.forEach((subscription: Subscription) => {
      subscription.unsubscribe();
    });
    this.subscriptions = [];
  }

  pageChanged(event: any): void {
    this.currentPage = event.page;
    this.getUserList();
  }

  getUserList() {
    this.ngxSpinnerService.show();
    console.log(this.selectedStatus);

    this.userService.getUserList(this.name, this.roleId, this.currentPage, this.pageSize, this.sortBy, this.selectedStatus).subscribe(response => {
      this.data = response.data;
      this.ngxSpinnerService.hide();
      this.totalRecordCount = response.totalRecordCount;
      this.pageSize = this.pageSize;
      this.currentPage = response.currentPage;
      this.totalPageCount = response.totalPageCount;
    }, err => {
      this.ngxSpinnerService.hide();
      this.toastrService.error('Unknown error has been occured.Please try again.');

    });
  }

  deleteUser(id: number) {

    this.eventService.deleteconfirmed$.subscribe(
      id => {
        this.ngxSpinnerService.show();
        this.userService.deleteUser(id).subscribe(response => {
          this.ngxSpinnerService.hide();
          if (response.isSuccess) {
            this.deleteModelRef.hide()
            this.toastrService.success(response.message, "Success");
            this.getUserList();
          }
          else {
            this.toastrService.error(response.message, "Error");
          }
        }, error => {
          this.ngxSpinnerService.hide();
          this.toastrService.error("Unknown error has been occured.Please try again.", "Error");
        })

      });

    this.deleteModelRef = this.bsModalService.show(ConfirmationDialogComponent,
      {
        class: 'modal-dialog-centered',
        backdrop: 'static',
        keyboard: false,
        initialState: {
          Id: id
        }
      });
  }

  confirm(msg): void {
    this.deleteModelRef.hide();
  }

  decline(msg): void {
    this.deleteModelRef.hide();
  }

  doSorting(value: string) {

    this.totalRecordCount = 0;
    this.totalPageCount = 0;
    this.currentPage = 1;
    this.sortBy = value;
    this.getUserList();
  }

  roleOnChange() {
    this.totalRecordCount = 0;
    this.totalPageCount = 0;
    this.currentPage = 1;
    this.getUserList();
  }

  statusOnChange() {
    this.totalRecordCount = 0;
    this.totalPageCount = 0;
    this.currentPage = 1;
    this.getUserList();
  }

  searchOnClick() {
    this.totalRecordCount = 0;
    this.totalPageCount = 0;
    this.currentPage = 1;
    this.getUserList();
  }
}
