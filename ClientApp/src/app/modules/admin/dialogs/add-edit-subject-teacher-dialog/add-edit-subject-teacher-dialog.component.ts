import { Component, OnInit } from '@angular/core';
import { AcademicLevelSubjectTeacherAllocationModel } from '../../../../models/master/subject-teacher/academic.level.subjects.teacher.allocation.model';
import { DropDownModel } from '../../../../models/common/drop-down.model';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { TeacherSubjectService } from '../../../../services/admin/teacher-subject.service';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AcademicLevelSubjectTeacherAllocationDetailModel } from '../../../../models/master/subject-teacher/academic.level.subject.teacher.allocation.detail.model';
import Swal from 'sweetalert2'
@Component({
  selector: 'app-add-edit-subject-teacher-dialog',
  templateUrl: './add-edit-subject-teacher-dialog.component.html',
  styleUrls: ['./add-edit-subject-teacher-dialog.component.css']
})
export class AddEditSubjectTeacherDialogComponent implements OnInit {

  teachSubjectAllocation: AcademicLevelSubjectTeacherAllocationModel;
  academicYears: DropDownModel[];
  selectedAcademicYearId: number;

  academicLevels: DropDownModel[];
  selectedAcademicLevelId: number;

  subjectId: number;
  subjectName: string;

  availableTeachers: DropDownModel[] = [];
  selectedSubjectTeacherId: number;

  assignedSubjectTeachers: DropDownModel[] = [];

  academicLevelSubjectTeacherAllocation: AcademicLevelSubjectTeacherAllocationDetailModel;

  constructor(private toastrService: ToastrService,
    private ngxSpinnerService: NgxSpinnerService,
    private teacherSubjectService: TeacherSubjectService,
    public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
    this.ngxSpinnerService.show();
    this.getAllTeachers();
  }


  getAllTeachers() {
    this.teacherSubjectService.getAllAvailableTeachers(this.selectedAcademicYearId, this.selectedAcademicLevelId, this.teachSubjectAllocation.subjectId)
      .subscribe(response => {
        this.availableTeachers = response;
        this.selectedSubjectTeacherId = this.availableTeachers.length > 0 ? this.availableTeachers[0].id : 0;
        this.getCurrentTeacherAllocation();
      }, error => {
        this.ngxSpinnerService.hide();
      });
  }

  getCurrentTeacherAllocation() {
    this.teacherSubjectService.getSubjectAllocationForSelectedAcademicLevel(this.selectedAcademicYearId, this.selectedAcademicLevelId, this.teachSubjectAllocation.subjectId)
      .subscribe(response => {
        this.ngxSpinnerService.hide();
        this.academicLevelSubjectTeacherAllocation = response;
        for (let index = 0; index < this.academicLevelSubjectTeacherAllocation.assignedTeachers.length; index++) {
          this.assignedSubjectTeachers.push(this.academicLevelSubjectTeacherAllocation.assignedTeachers[index]);

        }
      }, error => {
        this.ngxSpinnerService.hide();
      });
  }

  subjectTeacherChanged() {
    console.log(this.selectedSubjectTeacherId);

  }

  academicYearOnChange() {

  }

  assignedToSubject(item: number) {
    this.ngxSpinnerService.show();
    for (let index = 0; index < this.availableTeachers.length; index++) {
      if (this.availableTeachers[index].id == item) {

        this.assignedSubjectTeachers.push(this.availableTeachers[index]);
        this.availableTeachers.splice(index, 1);
        break;
      }
    }
    this.ngxSpinnerService.hide();
  }

  deleteItem(item: DropDownModel) {
    this.availableTeachers.push(item);
    for (let index = 0; index < this.assignedSubjectTeachers.length; index++) {
      if (item.id === this.assignedSubjectTeachers[index].id) {
        this.assignedSubjectTeachers.splice(index, 1);
        this.selectedSubjectTeacherId = this.availableTeachers[0].id;
        break;
      }
    }

  }

  save() {
    this.academicLevelSubjectTeacherAllocation.assignedTeachers = [];
    this.academicLevelSubjectTeacherAllocation.assignedTeachers = this.assignedSubjectTeachers;

    this.teacherSubjectService.saveSelectedSubjectAllocation(this.academicLevelSubjectTeacherAllocation)
      .subscribe(response => {

        if (response.isSuccess) {
          Swal.fire(
            'Success!',
            response.message,
            'success'
          )

          this.teacherSubjectService.onNewRecordAdded.next(true);
        }
        else {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: response.message
          })
        }

      }, error => {
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Something went wrong!. Please try again.'
        })
      });
  }
}
