import { Component, OnInit, AfterViewInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { DropDownModel } from '../../../../models/common/drop-down.model';
import { ClassTeacherService } from '../../../../services/admin/class-teacher.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { ThemeService } from 'ng2-charts';
import { ClassSubjectTeacherModel } from '../../../../models/master/class-subject-teacher/class-subject-teacher.model';
import { SubjectTeacherModel } from '../../../../models/master/class-subject-teacher/subject-teacher.model';
import Swal from 'sweetalert2';

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
  //selectedClassTecherId: number;
  isValidClassTeacher: boolean;
  inValidClassTeacherMsg: boolean;

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
          this.classSubjecTeacher.selectedClassTeacherId = this.availableClassTeachers[0].id;
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
        console.log(response);
        console.log("-----------------------");
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

  classTeacherOnChanged() {
    this.ngxSpinnerService.show();
    this.classTeacherService.validateClassTeacher(this.selectedAcademicYearId, this.selectedAcademicLevelId, this.selectedClassNameId, this.classSubjecTeacher.selectedClassTeacherId)
      .subscribe(response => {
        console.log(this.classSubjecTeacher);
        this.classSubjecTeacher.isvalidClassTeacher = response.isSuccess;
        this.classSubjecTeacher.validationMsg = response.message;
        this.ngxSpinnerService.hide();
      }, error => {
        this.ngxSpinnerService.hide();
      });
  }

  subjectTeacherOnChange(subjectid: number, subjectTeacherId: number, selectedSubject: SubjectTeacherModel) {
    this.ngxSpinnerService.show();
    this.classTeacherService.validateAssignedSubjectTeacher(this.selectedAcademicYearId, this.selectedAcademicLevelId, this.selectedClassNameId, subjectid, subjectTeacherId)
      .subscribe(response => {
        this.ngxSpinnerService.hide();
        if (response.isSuccess) {
          selectedSubject.isvalid = true;
        }
        else {
          selectedSubject.isvalid = false;
          selectedSubject.validationMsg = response.message;
        }

      }, error => {
        this.ngxSpinnerService.hide();
      });
  }


  save() {
    this.ngxSpinnerService.show();



    this.classTeacherService.saveClassSubjectTeacherDetails(this.classSubjecTeacher)
      .subscribe(response => {

        this.ngxSpinnerService.hide();
        if (response.isSuccess) {
          Swal.fire(
            'Success!',
            response.message,
            'success'
          )

          this.classTeacherService.onNewRecordAdded.next(true);
        }
        else {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: response.message
          })
        }
      }, error => {
        this.ngxSpinnerService.hide();
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Something went wrong!. Please try again.'
        })
      });

  }
}
