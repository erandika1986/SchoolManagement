import { ClassTeacherModel } from './class-teacher.model';
import { SubjectTeacherModel } from './subject-teacher.model';

export class ClassSubjectTeacherModel {
    academicYearId: number;
    academicLevelId: number;
    classNameId: number;

    classTeachers: ClassTeacherModel[];
    classSubjectTeachers: SubjectTeacherModel[];
}
