export class LockingDateModel {
    academicYearId: number;
    academicLevelId: string;
    subjectId: string;
    assessmentTypeId: string;
    tOSLockingDate: Date;
    resultLockingDate: Date;
    hasExam: boolean;
    isResultMigrated: boolean;
    migratedDate: Date;

    createdOn: Date;
    createdById: number;
    updatedOn: Date;
    updatedById: number;
}
