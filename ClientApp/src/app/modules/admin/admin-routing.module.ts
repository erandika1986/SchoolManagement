import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { AcademicLevelComponent } from './academic-level/academic-level.component';
import { ClassNameComponent } from './class-name/class-name.component';
import { AcademicYearComponent } from './academic-year/academic-year.component';
import { SubjectComponent } from './subject/subject.component';
import { StudentComponent } from './student/student.component';
import { HodComponent } from './hod/hod.component';
import { AssessmentTypeComponent } from './assessment-type/assessment-type.component';
import { ClassSubjectTeacherComponent } from './class-subject-teacher/class-subject-teacher.component';
import { SubjectTeacherComponent } from './subject-teacher/subject-teacher.component';


const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Admin'
    },
    children: [
      {
        path: 'user',
        component: UserComponent,
        data: {
          title: 'User'
        }
      },
      {
        path: 'academic-level',
        component: AcademicLevelComponent,
        data: {
          title: 'Academic Level'
        }
      },
      {
        path: 'class-name',
        component: ClassNameComponent,
        data: {
          title: 'Class Name'
        }
      },
      {
        path: 'subject',
        component: SubjectComponent,
        data: {
          title: 'Subject'
        }
      },
      {
        path: 'assessment-type',
        component: AssessmentTypeComponent,
        data: {
          title: 'Assessment Type'
        }
      },
      {
        path: 'student',
        component: StudentComponent,
        data: {
          title: 'Student'
        }
      },
      {
        path: 'hod',
        component: HodComponent,
        data: {
          title: 'Head of Department'
        }
      },
      {
        path: 'subject-teacher',
        component: SubjectTeacherComponent,
        data: {
          title: 'Subject Teacher'
        }
      },
      {
        path: 'class-subject-teacher',
        component: ClassSubjectTeacherComponent,
        data: {
          title: 'Class & Subject Teacher'
        }
      },

      {
        path: 'academic-year',
        component: AcademicYearComponent,
        data: {
          title: 'Academic Year'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
