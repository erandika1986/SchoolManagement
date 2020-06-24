import { Component, OnInit } from '@angular/core';
import { SubjectModel } from '../../../models/master/subject/subject.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Subscription } from 'rxjs';
import { SubjectService } from '../../../services/admin/subject.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { EventService } from '../../../services/common/event.service';
import { AddEditSubjectDialogComponent } from '../dialogs/add-edit-subject-dialog/add-edit-subject-dialog.component';
import { ConfirmationDialogComponent } from '../../shared/confirmation-dialog/confirmation-dialog.component';
import { NgOption } from '@ng-select/ng-select';

@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.css']
})
export class SubjectComponent implements OnInit {

  subjectId;
  name = '';
  sortBy = '';

  totalRecordCount = 0;
  totalPageCount = 0;
  currentPage = 1;
  pageSize = 15;

  data: SubjectModel[];

  public bsModalRef: BsModalRef;
  public deleteModelRef: BsModalRef;

  subscriptions: Subscription[] = [];

  constructor(
    private subjectService: SubjectService,
    private toastrService: ToastrService,
    private ngxSpinnerService: NgxSpinnerService,
    private bsModalService: BsModalService,
    private eventService: EventService) {

    this.eventService.subjectSaved$.subscribe(
      data => {

        this.ngxSpinnerService.show();
        this.subjectService.saveSubject(data).subscribe(response => {
          this.ngxSpinnerService.hide();
          if (response.isSuccess) {
            this.toastrService.clear();
            this.toastrService.success(response.message, "Success");
            this.getSubjectList();
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
        this.subjectService.deleteSubject(id).subscribe(response => {
          this.ngxSpinnerService.hide();
          if (response.isSuccess) {
            this.deleteModelRef.hide()
            this.toastrService.success(response.message, "Success");
            this.getSubjectList();
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
    this.getSubjectList();
  }

  getSubjectList() {
    this.ngxSpinnerService.show();
    this.subjectService.getAllSubjects(this.currentPage, this.pageSize, this.sortBy)
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

    this.bsModalRef = this.bsModalService.show(AddEditSubjectDialogComponent,
      {
        class: 'modal-xl modal-xxl  modal-dialog-centered',
        backdrop: 'static',
        keyboard: false,
        initialState: {
          subjectId: id
        }
      });
  }

  getBasketSubject(id: number) {

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
    this.getSubjectList();
  }

  doSorting(value: string) {

    this.totalRecordCount = 0;
    this.totalPageCount = 0;
    this.currentPage = 1;
    this.sortBy = value;
    this.getSubjectList();
  }

}
