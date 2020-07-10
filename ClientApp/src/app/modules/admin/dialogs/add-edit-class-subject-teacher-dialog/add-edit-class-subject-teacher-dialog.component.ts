import { Component, OnInit, AfterViewInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { DropDownModel } from '../../../../models/common/drop-down.model';
import { ClassTeacherService } from '../../../../services/admin/class-teacher.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { ThemeService } from 'ng2-charts';
import { ClassSubjectTeacherModel } from '../../../../models/master/class-subject-teacher/class-subject-teacher.model';

@Component({
  selector: 'app-add-edit-class-subject-teacher-dialog',
  templateUrl: './add-edit-class-subject-teacher-dialog.component.html',
  styleUrls: ['./add-edit-class-subject-teacher-dialog.component.css']
})
export class AddEditClassSubjectTeacherDialogComponent implements OnInit, AfterViewInit {

  academicYears: DropDownModel[];
  selectedAcademicYearId: number;

  academicLevels: DropDownModel[];
  selectedAcademicLevelId: number;

  classes: DropDownModel[];
  selectedClassNameId: number;
  type: string;

  availableClassTeachers: DropDownModel[];
  selectedClassTecherId: number;

  academicLevelSubjects: DropDownModel[];

  classSubjecTeacher: ClassSubjectTeacherModel = new ClassSubjectTeacherModel();

  constructor(
    private toastrService: ToastrService,
    private ngxSpinnerService: NgxSpinnerService,
    private classTeacherService: ClassTeacherService,
    public bsModalRef: BsModalRef) { }

  ngOnInit(): void {


  }

  ngAfterViewInit() {

    this.ngxSpinnerService.show();
    this.getClassTeachers();
  }

  getClassTeachers() {
    this.classTeacherService.getClassUnAssignedTeachers()
      .subscribe(respose => {

        this.availableClassTeachers = respose;
        this.getClassesForSelectedFilter();

      }, error => {
        this.ngxSpinnerService.hide();
      });
  }

  getClassesForSelectedFilter() {
    this.classTeacherService.getClassesForSelectedAcademicYearAndAcademicLevel(this.selectedAcademicYearId, this.selectedAcademicLevelId)
      .subscribe(response => {
        this.ngxSpinnerService.hide();
        this.classes = response;
        if (this.type !== "edit") {
          this.selectedClassNameId = response[0].id;
          this.selectedClassTecherId = this.availableClassTeachers[0].id;
        }

        this.getAcademicLevelSubjects();

      }, error => {

        this.ngxSpinnerService.hide();
      })
  }

  getAcademicLevelSubjects() {
    this.classTeacherService.getAcademicLevelSubjects(this.selectedAcademicLevelId)
      .subscribe(response => {
        this.academicLevelSubjects = response;
        this.getClassSubjectTeacherDetail();
      }, error => {
        this.ngxSpinnerService.hide();
      });
  }

  getClassSubjectTeacherDetail() {
    this.classTeacherService.getSelectedSubjectClassTeacherDetails(this.selectedAcademicYearId, this.selectedAcademicLevelId, this.selectedClassNameId)
      .subscribe(response => {
        this.classSubjecTeacher = response;
        this.ngxSpinnerService.hide();
      }, error => {
        this.ngxSpinnerService.hide();
      });
  }



  academicYearOnChange() {
    this.ngxSpinnerService.show();
    this.getClassSubjectTeacherDetail();
  }

  academicLevelOnChange() {
    this.ngxSpinnerService.show();
    this.getClassSubjectTeacherDetail();
  }

  classOnChange() {
    this.ngxSpinnerService.show();
    this.getClassSubjectTeacherDetail();
  }
}
