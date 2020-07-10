import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from '@ng-select/ng-select';

import { AdminRoutingModule } from './admin-routing.module';
import { UserComponent } from './user/user.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ModalModule } from 'ngx-bootstrap/modal';
import { MatDialogModule } from '@angular/material';
import { ConfirmationDialogComponent } from '../shared/confirmation-dialog/confirmation-dialog.component';
import { SharedModule } from '../shared/shared.module';
import { AddEditUserPopUpComponent } from './add-edit-user-pop-up/add-edit-user-pop-up.component';
//import { NgxDialogModule } from 'ngx-dialog';
import { EventService } from '../../services/common/event.service';
import { AcademicLevelComponent } from './academic-level/academic-level.component';
import { ClassNameComponent } from './class-name/class-name.component';
import { SubjectComponent } from './subject/subject.component';
import { AssessmentTypeComponent } from './assessment-type/assessment-type.component';
import { AcademicYearComponent } from './academic-year/academic-year.component';
import { HodComponent } from './hod/hod.component';
import { StudentComponent } from './student/student.component';
import { ClassSubjectTeacherComponent } from './class-subject-teacher/class-subject-teacher.component';
import { AddEditAcademicYearDialogComponent } from './dialogs/add-edit-academic-year-dialog/add-edit-academic-year-dialog.component';
import { AddEditAcademicLevelDialogComponent } from './dialogs/add-edit-academic-level-dialog/add-edit-academic-level-dialog.component';
import { ClassNameDialogComponent } from './dialogs/class-name-dialog/class-name-dialog.component';
import { AddEditClassNameDialogComponent } from './dialogs/add-edit-class-name-dialog/add-edit-class-name-dialog.component';
import { AddEditSubjectDialogComponent } from './dialogs/add-edit-subject-dialog/add-edit-subject-dialog.component';
import { AddEditAssessmentTypeDialogComponent } from './dialogs/add-edit-assessment-type-dialog/add-edit-assessment-type-dialog.component';
import { AddEditClassSubjectTeacherDialogComponent } from './dialogs/add-edit-class-subject-teacher-dialog/add-edit-class-subject-teacher-dialog.component';
import { SubjectTeacherComponent } from './subject-teacher/subject-teacher.component';


@NgModule({
  declarations: [UserComponent, AddEditUserPopUpComponent, AcademicLevelComponent, ClassNameComponent, SubjectComponent, AssessmentTypeComponent, AcademicYearComponent, HodComponent, StudentComponent, ClassSubjectTeacherComponent, AddEditAcademicYearDialogComponent, AddEditAcademicLevelDialogComponent, ClassNameDialogComponent, AddEditClassNameDialogComponent, AddEditSubjectDialogComponent, AddEditAssessmentTypeDialogComponent, AddEditClassSubjectTeacherDialogComponent, SubjectTeacherComponent],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    PaginationModule.forRoot(),
    ModalModule.forRoot(),
    MatDialogModule,
    SharedModule,
    //NgxDialogModule.forRoot(),
    NgSelectModule
  ],
  providers: [EventService],
  entryComponents: [ConfirmationDialogComponent, AddEditUserPopUpComponent, AddEditAcademicLevelDialogComponent, AddEditAcademicYearDialogComponent, AddEditClassNameDialogComponent, AddEditSubjectDialogComponent, AddEditAssessmentTypeDialogComponent, AddEditClassSubjectTeacherDialogComponent]
})
export class AdminModule { }
