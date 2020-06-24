import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ClassNameModel } from '../../../models/master/class-name/class-name.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { ClassNameService } from '../../../services/admin/class-name.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { EventService } from '../../../services/common/event.service';
import { ConfirmationDialogComponent } from '../../shared/confirmation-dialog/confirmation-dialog.component';
import { AddEditClassNameDialogComponent } from '../dialogs/add-edit-class-name-dialog/add-edit-class-name-dialog.component';

@Component({
  selector: 'app-class-name',
  templateUrl: './class-name.component.html',
  styleUrls: ['./class-name.component.css']
})
export class ClassNameComponent implements OnInit {

  name = '';
  sortBy = '';

  totalRecordCount = 0;
  totalPageCount = 0;
  currentPage = 1;
  pageSize = 15;

  data: ClassNameModel[];

  public bsModalRef: BsModalRef;
  public deleteModelRef: BsModalRef;

  subscriptions: Subscription[] = [];

  constructor
    (
      private classNameService: ClassNameService,
      private toastrService: ToastrService,
      private ngxSpinnerService: NgxSpinnerService,
      private bsModalService: BsModalService,
      private changeDetection: ChangeDetectorRef,
      private eventService: EventService
    ) {

    this.eventService.classNameSaved$.subscribe(
      data => {

        this.ngxSpinnerService.show();
        this.classNameService.saveClassName(data).subscribe(response => {
          this.ngxSpinnerService.hide();
          if (response.isSuccess) {
            this.toastrService.clear();
            this.toastrService.success(response.message, "Success");
            this.getClassNameList();
          }
          else {
            this.toastrService.error(response.message, "Error");
          }
        }, error => {
          this.ngxSpinnerService.hide();
          this.toastrService.error("Unknown error has been occured.Please try again.", "Error");
        })

      });

    this.eventService.deleteconfirmed$.subscribe(
      id => {
        this.ngxSpinnerService.show();
        this.classNameService.deleteClassName(id).subscribe(response => {
          this.ngxSpinnerService.hide();
          if (response.isSuccess) {
            this.deleteModelRef.hide()
            this.toastrService.success(response.message, "Success");
            this.getClassNameList();
          }
          else {
            this.toastrService.error(response.message, "Error");
          }
        }, error => {
          this.ngxSpinnerService.hide();
          this.toastrService.error("Unknown error has been occured.Please try again.", "Error");
        })

      });
  }

  ngOnInit(): void {

    this.getClassNameList();
  }


  getClassNameList() {
    this.ngxSpinnerService.show();
    this.classNameService.getAllClassNames(this.currentPage, this.pageSize, this.sortBy)
      .subscribe(response => {
        this.ngxSpinnerService.hide();
        this.data = response.data;
        this.totalRecordCount = response.totalRecordCount;
        this.pageSize = this.pageSize;
        this.currentPage = response.currentPage;
        this.totalPageCount = response.totalPageCount;

      }, error => {
        this.ngxSpinnerService.hide();
        this.toastrService.error('Unknown error has been occured.Please try again.');
      });
  }

  edit(id: number) {
    this.bsModalRef = this.bsModalService.show(AddEditClassNameDialogComponent,
      {
        class: 'modal-lg modal-dialog-centered',
        backdrop: 'static',
        keyboard: false,
        initialState: {
          classNameId: id
        }
      });

  }

  delete(id: number) {



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
  pageChanged(event: any): void {
    this.currentPage = event.page;
    this.getClassNameList();
  }

  doSorting(value: string) {

    this.totalRecordCount = 0;
    this.totalPageCount = 0;
    this.currentPage = 1;
    this.sortBy = value;
    this.getClassNameList();
  }

}
