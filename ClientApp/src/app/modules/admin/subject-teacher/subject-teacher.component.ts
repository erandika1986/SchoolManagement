import { Component, OnInit } from '@angular/core';
import { AcademicLevelSubjectTeacherAllocationModel } from '../../../models/master/subject-teacher/academic.level.subjects.teacher.allocation.model';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { DropDownModel } from '../../../models/common/drop-down.model';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { TeacherSubjectService } from '../../../services/admin/teacher-subject.service';

@Component({
  selector: 'app-subject-teacher',
  templateUrl: './subject-teacher.component.html',
  styleUrls: ['./subject-teacher.component.css']
})
export class SubjectTeacherComponent implements OnInit {

  name = '';
  sortBy = '';



  data: AcademicLevelSubjectTeacherAllocationModel[];

  public bsModalRef: BsModalRef;
  public deleteModelRef: BsModalRef;

  academicYears: DropDownModel[]
  selectedAcademicYearId: number;

  academicLevels: DropDownModel[];
  selectedAcademicLevelId: number;


  constructor(
    private teacherSubjectService: TeacherSubjectService,
    private toastrService: ToastrService,
    private ngxSpinnerService: NgxSpinnerService,
    private bsModalService: BsModalService,
  ) { }

  ngOnInit(): void {
    this.ngxSpinnerService.show();
    this.getMasterDate();
  }

  getMasterDate() {
    this.teacherSubjectService.getClassSubjectTeacherMasterData()
      .subscribe(response => {

        this.academicYears = response.academicYears;
        this.selectedAcademicYearId = this.academicYears[0].id;

        this.academicLevels = response.academicLevels;
        this.selectedAcademicLevelId = this.academicLevels[0].id;

        this.getSubjectTeacherAllocations();

      }, error => {
        this.ngxSpinnerService.hide();
      });
  }

  edit(vm: AcademicLevelSubjectTeacherAllocationModel) {

  }

  delete(vm: AcademicLevelSubjectTeacherAllocationModel) {

  }

  getSubjectTeacherAllocations() {
    this.teacherSubjectService.getAcademicYearSubjectTeacherAllocation(this.selectedAcademicYearId, this.selectedAcademicLevelId)
      .subscribe(response => {
        this.data = response;
        this.ngxSpinnerService.hide();
      }, error => {
        this.ngxSpinnerService.hide();
      });
  }

  academicYearOnChange() {
    this.ngxSpinnerService.show();
    this.getSubjectTeacherAllocations();
  }

  academicLevelOnChange() {
    this.ngxSpinnerService.show();
    this.getSubjectTeacherAllocations();
  }
}
