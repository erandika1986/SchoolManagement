export class HeadOfDepartmentModel {
    id: number;
    academicYearId: number;
    academicLevelId: string;
    subjectId: string;
    teacherId: number;

    isActive: boolean;
    createdOn: Date;
    createdById: number;
    updatedOn: Date;
    updatedById: number;
}
