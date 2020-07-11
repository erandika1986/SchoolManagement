import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ClassSubjectTeacherBasicDetailModel } from '../../../models/master/class-subject-teacher/class.subject.teacher.basic.detail.model';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { ClassTeacherService } from '../../../services/admin/class-teacher.service';
import { DropDownModel } from '../../../models/common/drop-down.model';
import { AddEditClassSubjectTeacherDialogComponent } from '../dialogs/add-edit-class-subject-teacher-dialog/add-edit-class-subject-teacher-dialog.component';

@Component({
  selector: 'app-class-subject-teacher',
  templateUrl: './class-subject-teacher.component.html',
  styleUrls: ['./class-subject-teacher.component.css']
})
export class ClassSubjectTeacherComponent implements OnInit {

  name = '';
  sortBy = '';

  totalRecordCount = 0;
  totalPageCount = 0;
  currentPage = 1;
  pageSize = 15;

  data: ClassSubjectTeacherBasicDetailModel[];

  public bsModalRef: BsModalRef;
  public deleteModelRef: BsModalRef;




  academicYears: DropDownModel[]
  selectedAcademicYearId: number;

  academicLevels: DropDownModel[];
  selectedAcademicLevelId: number;


  constructor(
    private classSubjectTecherService: ClassTeacherService,
    private toastrService: ToastrService,
    private ngxSpinnerService: NgxSpinnerService,
    private bsModalService: BsModalService,
  ) { }

  ngOnInit(): void {

    this.ngxSpinnerService.show();
    this.getMasterDate();
  }

  getMasterDate() {
    this.classSubjectTecherService.getClassSubjectTeacherMasterData()
      .subscribe(response => {

        this.academicYears = response.academicYears;
        this.selectedAcademicYearId = this.academicYears[0].id;

        this.academicLevels = response.academicLevels;
        this.selectedAcademicLevelId = this.academicLevels[0].id;

        this.getClassTeacherSubjectTeacherAllocations();
      }, error => {
        this.ngxSpinnerService.hide();
      });
  }

  getClassTeacherSubjectTeacherAllocations() {
    this.classSubjectTecherService.getAllSubjectClassTeachers(this.currentPage, this.pageSize, this.sortBy, this.selectedAcademicYearId, this.selectedAcademicLevelId)
      .subscribe(response => {

        this.totalRecordCount = response.totalRecordCount;
        this.totalPageCount = response.totalPageCount;
        this.data = response.data;

        this.ngxSpinnerService.hide();
      }, error => {
        this.ngxSpinnerService.hide();
      });
  }


  academicYearOnChange() {
    this.totalRecordCount = 0;
    this.totalPageCount = 0;
    this.currentPage = 1;
    this.ngxSpinnerService.show();
    this.getClassTeacherSubjectTeacherAllocations();
  }

  academicLevelOnChange() {
    this.totalRecordCount = 0;
    this.totalPageCount = 0;
    this.currentPage = 1;
    this.ngxSpinnerService.show();
    this.getClassTeacherSubjectTeacherAllocations();
  }

  edit(academicYear: number, academicLevel: number, classNameId: number) {

    const initialState = {

      academicYears: this.academicYears,
      selectedAcademicYearId: academicYear,
      academicLevels: this.academicLevels,
      selectedAcademicLevelId: academicLevel,
      selectedClassNameId: classNameId,
      type: classNameId == 0 ? "new" : "edit"
    };

    this.bsModalRef = this.bsModalService.show(AddEditClassSubjectTeacherDialogComponent, {
      class: 'modal-xl modal-dialog-centered',
      backdrop: 'static',
      keyboard: false, initialState
    });
  }

  pageChanged(event: any): void {
    this.ngxSpinnerService.show();
    this.currentPage = event.page;
    this.getClassTeacherSubjectTeacherAllocations();
  }

  doSorting(value: string) {

  }

}
