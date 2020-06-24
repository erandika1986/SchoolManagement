export class ClassTimeTablePeriodAssignTeacher {
    id: number;
    classTimeTablePeriodId: number;
    teacherId: number;
    allocatedDate: Date;
    deallocatedDate: Date;

    isActive: boolean;
    createdOn: Date;
    createdById: number;
    updatedOn: Date;
    updatedById: number;
}
