import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { AssessmentTypeModel } from '../../../models/master/assessment-type/assessment-type.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { EventService } from '../../../services/common/event.service';
import { AssessmentTypeService } from '../../../services/admin/assessment-type.service';
import { AddEditAssessmentTypeDialogComponent } from '../dialogs/add-edit-assessment-type-dialog/add-edit-assessment-type-dialog.component';
import { ConfirmationDialogComponent } from '../../shared/confirmation-dialog/confirmation-dialog.component';

@Component({
  selector: 'app-assessment-type',
  templateUrl: './assessment-type.component.html',
  styleUrls: ['./assessment-type.component.css']
})
export class AssessmentTypeComponent implements OnInit {

  name = '';
  sortBy = '';

  totalRecordCount = 0;
  totalPageCount = 0;
  currentPage = 1;
  pageSize = 15;

  data: AssessmentTypeModel[];

  public bsModalRef: BsModalRef;
  public deleteModelRef: BsModalRef;

  subscriptions: Subscription[] = [];

  constructor(
    private assessementTypeService: AssessmentTypeService,
    private toastrService: ToastrService,
    private ngxSpinnerService: NgxSpinnerService,
    private bsModalService: BsModalService,
    private changeDetection: ChangeDetectorRef,
    private eventService: EventService) {

    this.eventService.assessmentTypeSaved$.subscribe(
      data => {

        this.ngxSpinnerService.show();
        this.assessementTypeService.saveAssessmentType(data).subscribe(response => {
          this.ngxSpinnerService.hide();
          if (response.isSuccess) {
            this.toastrService.clear();
            this.toastrService.success(response.message, "Success");
            this.getAssessmentTypeList();
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
        this.assessementTypeService.deleteAssessmentType(id).subscribe(response => {
          this.ngxSpinnerService.hide();
          if (response.isSuccess) {
            this.deleteModelRef.hide()
            this.toastrService.success(response.message, "Success");
            this.getAssessmentTypeList();
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

    this.getAssessmentTypeList();
  }


  getAssessmentTypeList() {
    this.ngxSpinnerService.show();
    this.assessementTypeService.getAllAssessmentTypes(this.currentPage, this.pageSize, this.sortBy)
      .subscribe(response => {
        console.log(response);

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
    this.bsModalRef = this.bsModalService.show(AddEditAssessmentTypeDialogComponent,
      {
        class: 'modal-lg modal-dialog-centered',
        backdrop: 'static',
        keyboard: false,
        initialState: {
          assessmentTypeId: id
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
    this.getAssessmentTypeList();
  }

  doSorting(value: string) {

    this.totalRecordCount = 0;
    this.totalPageCount = 0;
    this.currentPage = 1;
    this.sortBy = value;
    this.getAssessmentTypeList();
  }

}
