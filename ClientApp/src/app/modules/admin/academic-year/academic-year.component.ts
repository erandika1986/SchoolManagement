import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { AcademicYearService } from '../../../services/admin/academic-year.service';
import { AcademicYearModel } from '../../../models/master/academic-year/academic-year.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { EventService } from '../../../services/common/event.service';
import { ConfirmationDialogComponent } from '../../shared/confirmation-dialog/confirmation-dialog.component';
import { AddEditAcademicLevelDialogComponent } from '../dialogs/add-edit-academic-level-dialog/add-edit-academic-level-dialog.component';
import { AddEditAcademicYearDialogComponent } from '../dialogs/add-edit-academic-year-dialog/add-edit-academic-year-dialog.component';

@Component({
  selector: 'app-academic-year',
  templateUrl: './academic-year.component.html',
  styleUrls: ['./academic-year.component.css']
})
export class AcademicYearComponent implements OnInit {

  name = '';
  roleId = 0;
  sortBy = '';

  totalRecordCount = 0;
  totalPageCount = 0;
  currentPage = 1;
  pageSize = 15;

  data: AcademicYearModel[];

  public bsModalRef: BsModalRef;
  public deleteModelRef: BsModalRef;

  subscriptions: Subscription[] = [];

  constructor
    (
      private academicYearService: AcademicYearService,
      private toastrService: ToastrService,
      private ngxSpinnerService: NgxSpinnerService,
      private bsModalService: BsModalService,
      private changeDetection: ChangeDetectorRef,
      private eventService: EventService
    ) {

    this.eventService.academicYearSaved$.subscribe(
      data => {

        this.ngxSpinnerService.show();
        if (data.id == 0) {
          this.academicYearService.saveAcademicYear(data).subscribe(response => {
            this.ngxSpinnerService.hide();
            if (response.isSuccess) {
              this.bsModalRef.hide()
              this.toastrService.clear();
              this.toastrService.success(response.message, "Success");
              this.getAcademicYears();
            }
            else {
              this.toastrService.error(response.message, "Error");
            }
          }, error => {
            this.ngxSpinnerService.hide();
            this.toastrService.error("Unknown error has been occured.Please try again.", "Error");
          });
        }
        else {
          this.academicYearService.updateAcademicYear(data).subscribe(response => {
            this.ngxSpinnerService.hide();
            if (response.isSuccess) {
              this.bsModalRef.hide()
              this.toastrService.clear();
              this.toastrService.success(response.message, "Success");
              this.getAcademicYears();
            }
            else {
              this.toastrService.error(response.message, "Error");
            }
          }, error => {
            this.ngxSpinnerService.hide();
            this.toastrService.error("Unknown error has been occured.Please try again.", "Error");
          });
        }


      });

    this.eventService.deleteconfirmed$.subscribe(
      id => {
        this.ngxSpinnerService.show();
        this.academicYearService.deleteAcademivYear(id).subscribe(response => {
          this.ngxSpinnerService.hide();
          if (response.isSuccess) {
            this.deleteModelRef.hide()
            this.toastrService.success(response.message, "Success");
            this.getAcademicYears();
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

    this.getAcademicYears();
  }


  getAcademicYears() {
    this.ngxSpinnerService.show();
    this.academicYearService.getAllAcademicYearClassDetails(this.currentPage, this.pageSize, this.sortBy)
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
    this.bsModalRef = this.bsModalService.show(AddEditAcademicYearDialogComponent,
      {
        class: 'modal-lg modal-dialog-centered',
        backdrop: 'static',
        keyboard: false,
        initialState: {
          academicYearId: id,
          action: id == 0 ? "new" : "edit"
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
    this.getAcademicYears();
  }

  doSorting(value: string) {

    this.totalRecordCount = 0;
    this.totalPageCount = 0;
    this.currentPage = 1;
    this.sortBy = value;
    this.getAcademicYears();
  }

}
