import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { AcademicLevelService } from '../../../services/admin/academic-level.service';
import { AcademicLevelModel } from '../../../models/master/academic-level/academic-level.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { MatDialog } from '@angular/material';
import { EventService } from '../../../services/common/event.service';
import { AddEditAcademicLevelDialogComponent } from '../dialogs/add-edit-academic-level-dialog/add-edit-academic-level-dialog.component';
import { ConfirmationDialogComponent } from '../../shared/confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-academic-level',
  templateUrl: './academic-level.component.html',
  styleUrls: ['./academic-level.component.css']
})
export class AcademicLevelComponent implements OnInit {

  name = '';
  roleId = 0;
  sortBy = '';

  totalRecordCount = 0;
  totalPageCount = 0;
  currentPage = 1;
  pageSize = 15;

  data: AcademicLevelModel[];

  public bsModalRef: BsModalRef;
  public deleteModelRef: BsModalRef;

  subscriptions: Subscription[] = [];

  constructor
    (
      private academicLevelService: AcademicLevelService,
      private toastrService: ToastrService,
      private ngxSpinnerService: NgxSpinnerService,
      private bsModalService: BsModalService,
      private changeDetection: ChangeDetectorRef,
      private eventService: EventService
    ) {

    this.eventService.academicLevelSaved$.subscribe(
      data => {

        this.ngxSpinnerService.show();
        this.academicLevelService.saveAcademicLevel(data).subscribe(response => {
          this.ngxSpinnerService.hide();
          if (response.isSuccess) {
            this.bsModalRef.hide()
            this.toastrService.clear();
            this.toastrService.success(response.message, "Success");
            this.getAcademicYearList();
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
        this.academicLevelService.deleteAcademivLevel(id).subscribe(response => {
          this.ngxSpinnerService.hide();
          if (response.isSuccess) {
            this.deleteModelRef.hide()
            this.toastrService.success(response.message, "Success");
            this.getAcademicYearList();
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

    this.getAcademicYearList();
  }


  getAcademicYearList() {
    this.ngxSpinnerService.show();
    this.academicLevelService.getAllAcademicLevels(this.currentPage, this.pageSize, this.sortBy)
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
    this.bsModalRef = this.bsModalService.show(AddEditAcademicLevelDialogComponent,
      {
        class: 'modal-lg modal-dialog-centered',
        backdrop: 'static',
        keyboard: false,
        initialState: {
          academicLevelId: id
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
    this.getAcademicYearList();
  }

  doSorting(value: string) {

    this.totalRecordCount = 0;
    this.totalPageCount = 0;
    this.currentPage = 1;
    this.sortBy = value;
    this.getAcademicYearList();
  }

}
