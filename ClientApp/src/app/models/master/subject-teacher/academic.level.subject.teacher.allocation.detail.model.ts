import { DropDownModel } from '../../common/drop-down.model';

export class AcademicLevelSubjectTeacherAllocationDetailModel {
    academicYearId: number;
    academicLevelId: number;
    subjectId: number;
    assignedTeachers: DropDownModel[];
}