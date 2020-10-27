import { ClassTeacherModel } from './class-teacher.model';
import { SubjectTeacherModel } from './subject-teacher.model';

export class ClassSubjectTeacherModel {
    academicYearId: number;
    academicLevelId: number;
    classNameId: number;
    selectedClassTeacherId: number;
    selectedClassCategory: number;
    selectedLanguageStream: number;
    isvalidClassTeacher: boolean;
    validationMsg: string;

    //classTeachers: ClassTeacherModel[];
    classSubjectTeachers: SubjectTeacherModel[];
}
